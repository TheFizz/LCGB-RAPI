using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCGB
{
    class LCGBSummoner
    {
        private string _nickname;
        private string _rank;
        private string _iconurl;
        private string _rankurl;
        private int _points;

        public LCGBSummoner(string nickname, string rank, int points, string iconurl, string rankurl)
        {
            _nickname = nickname;
            _rank = rank;
            _points = points;
            _iconurl = iconurl;
            _rankurl = rankurl;
        }

        public string iconurl
        {
            get
            {
                return _iconurl;
            }
        }
        public string rank
        {
            get
            {
                return _rank;
            }
        }
        public string nickname
        {
            get
            {
                return _nickname;
            }
        }
        public string rankurl
        {
            get
            {
                return _rankurl;
            }
        }
        public int points
        {
            get
            {
                return _points;
            }
        }
    }
}
