namespace IO.Model.Tables
{
    enum PhysicalCondition
    {

    }
    public class TableEntity
    {
        public string TableID { get; set; }
        public bool IsBusy { get; set; }

        public string TableBrand { get; set; }
    }
}