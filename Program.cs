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
using System.Linq;
using System.Windows.Forms;

namespace AVIAssembler
{
  static class Program
  {
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new AVIAsm());
    }
  }
}
