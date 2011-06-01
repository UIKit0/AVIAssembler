/**
 * AVIAssembler - turn image sequences into AVI movies
 *
 * Written by Harry Denholm (Ishani)
 * http://www.ishani.org/
 *
 * Released under MIT Licence (http://www.opensource.org/licenses/mit-license.php)
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.IO;
using System.Threading;

namespace AVIAssembler
{
  public partial class AVIAsm : Form
  {
    private XmlSerializer mSettingsSerializer;
    private Settings mSettings;

    public AVIAsm()
    {
      InitializeComponent();
      checkInputFields();

      mSettingsSerializer = new XmlSerializer(typeof(Settings));
    }

    private void AVIAsm_Load(object sender, EventArgs e)
    {
      if (File.Exists("Settings.xml"))
      {
        TextReader reader = null;
        try
        {
          reader = new StreamReader("Settings.xml");
          mSettings = mSettingsSerializer.Deserialize(reader) as Settings;
        }
        catch (System.Exception ex)
        {
          MessageBox.Show("There was a problem reading the Settings.xml : \n\n" + ex.Message, this.Text);
        }
        finally
        {
          if (reader != null)
            reader.Close();
        }
      }
      else
      {
        mSettings = new Settings();
        mSettings.PreviousSearchExpressions.Add("render_{0:D5}.png");
      }

      if (mSettings != null)
      {
        foreach (string ns in mSettings.PreviousSearchPaths)
        {
          if (!mSearchPath.Items.Contains(ns))
            mSearchPath.Items.Add(ns);
        }
        foreach (string ns in mSettings.PreviousSearchExpressions)
        {
          if (!mSearchExpr.Items.Contains(ns))
            mSearchExpr.Items.Add(ns);
        }
      }
    }

    private void AVIAsm_Closing(object sender, FormClosingEventArgs e)
    {
      if (mSettings == null)
        mSettings = new Settings();

      try
      {
        TextWriter writer = new StreamWriter("Settings.xml");
        mSettingsSerializer.Serialize(writer, mSettings);
        writer.Close();
      }
      catch (System.Exception ex)
      {
        MessageBox.Show("There was a problem saving the Settings.xml : \n\n" + ex.Message);      	
      }
      finally
      {
      }
    }

    private void mBrowse_Click(object sender, EventArgs e)
    {
      if (mBrowseForPath.ShowDialog() == DialogResult.OK)
      {
        mSearchPath.Text = mBrowseForPath.SelectedPath;
      }
    }

    private void gatherFiles(List<String> listOfImages)
    {
      Cursor.Current = Cursors.WaitCursor;

      listOfImages.Clear();

      String searchPath = Path.GetFullPath(mSearchPath.Text + "\\");

      // work out indices
      Int32 sIndex = (Int32)mIndexStart.Value;
      Int32 eIndex = Int32.MaxValue;
      if (mIterateNumerical.Checked)
        eIndex = (Int32)mIndexEnd.Value;

      mProgress.Style = ProgressBarStyle.Marquee;
      for (Int32 i = sIndex; i <= eIndex; i++)
      {
        String fn = searchPath + getFormattedFilename(i);

        if (File.Exists(fn))
        {
          listOfImages.Add(fn);
        }
        else
        {
          mProgress.Style = ProgressBarStyle.Continuous;

          if (mIterateUntilError.Checked)
            return;

          throw new Exception("Failed; Could not find file : " + fn);
        }

        Application.DoEvents();
      }
      mProgress.Style = ProgressBarStyle.Continuous;
    }

    private bool gatherAndCheckFiles(List<String> images)
    {
      try
      {
        gatherFiles(images);
      }
      catch (System.Exception ex)
      {
        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }

      if (images.Count == 0)
      {
        MessageBox.Show("Failed; No images found!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }

      return true;
    }

    private void mValidate_Click(object sender, EventArgs e)
    {
      List<String> images = new List<String>(32);
      mAssemble.Enabled = gatherAndCheckFiles(images);

      MessageBox.Show(String.Format("Success! Found {0} image files.", images.Count), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void mAssemble_Click(object sender, EventArgs e)
    {
      if (mChooseOutputFile.ShowDialog() != DialogResult.OK)
        return;

      List<String> images = new List<String>(32);
      if (gatherAndCheckFiles(images))
      {        
        try
        {
          using (Ishani.Encoder.AVI aviEncoder = new Ishani.Encoder.AVI())
          {
            Cursor.Current = Cursors.WaitCursor;

            mProgress.Style = ProgressBarStyle.Continuous;
            mProgress.Maximum = images.Count;

            Bitmap sample = new Bitmap(images[0]);            
            aviEncoder.beginSequence(this, sample, mChooseOutputFile.FileName, (Int32)mFPS.Value);

            foreach (String img in images)
            {
              Bitmap nextFrame = new Bitmap(img);
              aviEncoder.addBitmap(nextFrame);

              mProgress.Value++;
              mProgress.Refresh();
              Application.DoEvents();
            }

            aviEncoder.endSequence();
          }

          MessageBox.Show(String.Format("Successfully assembled {0} images into '{1}'", images.Count, mChooseOutputFile.FileName), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

          // store a successful run in the settings
          if (!mSettings.PreviousSearchExpressions.Contains(mSearchExpr.Text))
            mSettings.PreviousSearchExpressions.Add(mSearchExpr.Text);
          if (!mSettings.PreviousSearchPaths.Contains(mSearchPath.Text))
            mSettings.PreviousSearchPaths.Add(mSearchPath.Text);
        }
        catch (System.Exception ex)
        {
          MessageBox.Show("Error during assembly : \n\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
          mProgress.Value = 0;
        }
      }
    }

    private void checkIndexRange(object sender, EventArgs e)
    {
      if (mIterateNumerical.Checked && mIndexEnd.Value < mIndexStart.Value)
      {
        mIndexEnd.BackColor = Color.PeachPuff;
        mIndexStart.BackColor = Color.PeachPuff;
        mValidate.Enabled = false;
      }
      else
      {
        mIndexEnd.BackColor = SystemColors.Window;
        mIndexStart.BackColor = SystemColors.Window;
        mValidate.Enabled = true;
      }

      mAssemble.Enabled = false;
    }

    private void incrementChanged(object sender, EventArgs e)
    {
      mIndexEnd.Enabled = mIterateNumerical.Checked;
      checkIndexRange(sender, e);
    }

    private String getFormattedFilename(Int32 index)
    {
      try
      {
        return String.Format(mSearchExpr.Text, index);
      }
      catch (System.Exception)
      {
      	return mSearchExpr.Text;
      }
    }

    private bool checkSearchExpr()
    {
      String formatted = getFormattedFilename(123);
      if (formatted == mSearchExpr.Text) // hasnt changed after formatting
        return false;

      return true;
    }

    // any invalid paths are flagged pink
    private void checkInputFields()
    {
      bool validInp = false;

      if (Directory.Exists(mSearchPath.Text))
      {
        mSearchPath.BackColor = SystemColors.Window;
        validInp = true;
      }
      else
      {
        mSearchPath.BackColor = Color.PeachPuff;
      }

      if (checkSearchExpr())
      {
        mSearchExpr.BackColor = SystemColors.Window;
        validInp &= true;
      }
      else
      {
        mSearchExpr.BackColor = Color.PeachPuff;
        validInp = false;
      }

      mValidate.Enabled = validInp;
      mAssemble.Enabled = false;
    }

    private void mSearchPath_TextUpdate(object sender, EventArgs e)
    {
      checkInputFields();
    }

    private void mSearchExpr_TextUpdate(object sender, EventArgs e)
    {
      checkInputFields();
    }
  }
}
