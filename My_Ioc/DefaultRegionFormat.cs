using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Ioc
{
    public class DefaultRegionFormat : IRegionFormat
    {
        public string FormatName
        {
            get
            {
                { return "默认时间格式"; }
            }
        }

        public string GetShortTimeString(DateTime time)
        {
            return time.ToString("yyyy-MM-dd");
        }
    }
}
