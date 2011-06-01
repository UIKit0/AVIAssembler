/**
 * AVIAssembler - turn image sequences into AVI movies
 *
 *  Ishani.Encoder 
 *  Managed .NET module that provides simple interface to Windows AVI creation APIs
 * 
 * Written by Harry Denholm (Ishani)
 * http://www.ishani.org/
 *
 * Released under MIT Licence (http://www.opensource.org/licenses/mit-license.php)
 */

#pragma once

using namespace System;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Drawing;
using namespace System::Drawing::Imaging;
using namespace System::Runtime::InteropServices;


namespace Ishani
{
  namespace Encoder
  {
    ////////////////////////////////////////////////////////////////////////////////
    // CLASS AVIisc
    //
    // AVI compressor class, used to create Microsoft's AVI movie files
    public ref class AVI 
    {
    private:

      // size in bytes of a single frame
      int				mFrameBufferSize;

      // the AVI file, and two streams in use
      IAVIFile		**mIAVIFile;
      IAVIStream		**mAVIVideoStream, **mAVIComp;

      // current frame to be writing to
      int				mFrameCount;

      // cached values about the image 
      int				mImageW, mImageH;

    public:

      ////////////////////////////////////////////////////////////////////////////////
      // CTOR AVIisc
      //
      // 
      AVI()
      {
        mIAVIFile = (IAVIFile**)malloc(sizeof(IAVIFile*));
        mAVIVideoStream = (IAVIStream**)malloc(sizeof(IAVIStream*));
        mAVIComp = (IAVIStream**)malloc(sizeof(IAVIStream*));
      }

      ////////////////////////////////////////////////////////////////////////////////
      // DTOR ~AVIisc
      //
      // 
      ~AVI(void)
      {
        if (mAVIComp)
        {
          free(mAVIComp);
        }

        if (mAVIVideoStream)
        {
          free(mAVIVideoStream);
        }

        if (mIAVIFile)
        {
          free(mIAVIFile);
        }
      }


      ////////////////////////////////////////////////////////////////////////////////
      // METHOD beginSequence
      //
      // setup an AVI file to write out to, using the sampleImage provided as a template
      // for compressed formats, etc. 
      void beginSequence(
        Form ^parent,
        Bitmap ^sampleImage,
        String ^outputFilename,
        Int32 fps)
      {
        HRESULT hr;

        // check on vital incoming variables
        if (!sampleImage)
        {
          throw (gcnew Exception(gcnew String("sampleImage variable not provided to beginSequence call")));
        }
        if (!outputFilename)
        {
          throw (gcnew Exception(gcnew String("outputFilename variable not provided to beginSequence call")));
        }

        // open AVI file library
        AVIFileInit();

        // convert managed String to char stream
        const char* fName = (const char*)
          (Marshal::StringToHGlobalAnsi(outputFilename)).ToPointer();

        // open a new AVI file to write to
        hr = AVIFileOpen(mIAVIFile, fName, OF_WRITE|OF_CREATE, NULL);
        if (hr != AVIERR_OK)
        {
          throw (gcnew Exception(gcnew String("AVIFileOpen failed")));
        }

        // free managed string conversion
        Marshal::FreeHGlobal(IntPtr((void*)fName));


        // cache image dimensions
        mImageW = sampleImage->Width;
        mImageH = sampleImage->Height;

        // convert image into DIB section
        HBITMAP hbm = (HBITMAP)sampleImage->GetHbitmap().ToPointer();
        DIBSECTION dibs; 
        int sbm = GetObject(hbm, sizeof(DIBSECTION), &dibs);

        // get maximum size of one frame
        mFrameBufferSize = dibs.dsBmih.biSizeImage; 

        // setup our AVI stream
        AVISTREAMINFO strhdr; 
        ZeroMemory(&strhdr, sizeof(AVISTREAMINFO));
        strhdr.fccType = streamtypeVIDEO;
        strhdr.fccHandler = 0;
        strhdr.dwScale = 1;
        strhdr.dwRate = fps;
        strhdr.dwSuggestedBufferSize = mFrameBufferSize;
        SetRect(&strhdr.rcFrame, 0, 0, mImageW, mImageH);

        // create new stream to write to
        hr = AVIFileCreateStream(*mIAVIFile, mAVIVideoStream, &strhdr);
        if (hr != AVIERR_OK)
        {
          throw (gcnew Exception(gcnew String("AVIFileCreateStream failed")));
        }

        // open the AVI compression options window
        AVICOMPRESSOPTIONS opt, *aopts[1];
        ZeroMemory(&opt,sizeof(AVICOMPRESSOPTIONS));
        aopts[0] = &opt;

        HWND owningWindow = (parent != nullptr)?(HWND)parent->Handle.ToInt32():NULL;
        if (!AVISaveOptions(
          owningWindow,
          ICMF_CHOOSE_DATARATE | ICMF_CHOOSE_KEYFRAME | ICMF_CHOOSE_PREVIEW,
          1,
          mAVIVideoStream,
          aopts))
        {
          throw (gcnew Exception(gcnew String("User aborted")));
        }

        // create a new compressed stream using these options
        hr = AVIMakeCompressedStream(mAVIComp, *mAVIVideoStream, aopts[0], NULL);

        // check to see if the compressed stream was built ok
        AVISaveOptionsFree(1,aopts);
        if (hr != AVIERR_OK)
        {
          throw (gcnew Exception(gcnew String("AVIMakeCompressedStream failed")));
        }

        // set the format of the new compressed stream to the format of
        // our incoming bitmap
        hr = AVIStreamSetFormat(
          *mAVIComp, 
          0, 
          &dibs.dsBmih, 
          dibs.dsBmih.biSize + dibs.dsBmih.biClrUsed * sizeof(RGBQUAD));

        // everything ok?
        if (hr != AVIERR_OK)
        {
          throw (gcnew Exception(gcnew String("AVIStreamSetFormat failed")));
        }

        // release bitmap object
        DeleteObject(hbm);

        // reset frame counter
        mFrameCount = 0;
      }

      ////////////////////////////////////////////////////////////////////////////////
      // METHOD addBitmap
      //
      // 
      void addBitmap(
        Bitmap ^image)
      {
        // convert this image into a DIB section to get at the data
        HBITMAP hbm = (HBITMAP)image->GetHbitmap().ToPointer();
        DIBSECTION dibs; 
        int sbm = GetObject(hbm,sizeof(dibs),&dibs);

        // write compressed data to stream
        HRESULT hr = AVIStreamWrite(
          *mAVIComp,
          mFrameCount,
          1,
          dibs.dsBm.bmBits, dibs.dsBmih.biSizeImage,
          AVIIF_KEYFRAME,
          NULL,
          NULL);

        // release the converted bitmap
        DeleteObject(hbm);

        // up the frame count
        mFrameCount ++;
      }

      ////////////////////////////////////////////////////////////////////////////////
      // METHOD endSequence
      //
      // call to finish adding frames, close the AVI streams and write out 
      // all changes to a finished file
      void endSequence(void)
      {
        // close the opened streams and file
        AVIStreamRelease(*mAVIComp);
        AVIStreamRelease(*mAVIVideoStream);
        AVIFileRelease(*mIAVIFile);

        // close AVI file library
        AVIFileExit();
      }
    };
  }
}
