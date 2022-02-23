using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFIndexSimulator
{
    public class CalcParamsEntity
    {
        private int _intDelayMilliseconds;

        public int intDelayMilliseconds
        {
            get { return _intDelayMilliseconds; }
            set { _intDelayMilliseconds = value; }
        }

        private int _intLoopCnt;

        public int intLoopCnt
        {
            get { return _intLoopCnt; }
            set { _intLoopCnt = value; }
        }

        private string _strIndexCode;

        public string strIndexCode
        {
            get { return _strIndexCode; }
            set { _strIndexCode = value; }
        }
    }
}
