namespace FirstCoreApp.Data
{
    public static class CommonLogic
    {
        public static int CalculateAge(DateOnly BirthDate) 
        {
            if (BirthDate.ToString() == "1/1/0001")
            {
                return 0;
            }
            var TodayDate = DateTime.Now;
            var Age = TodayDate.Year - BirthDate.Year; 
            return Age;
        }    
    }
}
