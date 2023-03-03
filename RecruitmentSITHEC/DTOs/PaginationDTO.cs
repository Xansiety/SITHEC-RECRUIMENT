namespace RecruitmentSITHEC.DTOS
{
    public class PaginationDTO
    {
        private int _pageSize = 5;
        private const int MaxPageSize = 50;
        private int _pageIndex = 1;
 
        public int RecordsPerPage
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public int Page
        {
            get => _pageIndex;
            set => _pageIndex = (value <= 0) ? 1 : value;
        } 
    }
}
