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
using System.Text;
using System.Xml;

namespace AVIAssembler
{
  [Serializable]
  public class Settings
  {
    public List<String> PreviousSearchPaths = new List<String>();
    public List<String> PreviousSearchExpressions = new List<String>();
  }
}
