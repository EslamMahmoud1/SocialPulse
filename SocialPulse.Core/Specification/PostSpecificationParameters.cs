namespace SocialPulse.Core.Specification
{
    public class PostSpecificationParameters
    {
        private const int MAXPAGESIZE = 10;
        public Sort? Sort { get; set; }
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 5;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > MAXPAGESIZE ? MAXPAGESIZE : value; }
        }


    }
    public enum Sort
    {
        Asc, Desc
    }
}
