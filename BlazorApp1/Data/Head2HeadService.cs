namespace BlazorApp1.Data
{
    public class Head2HeadService
    {
        private readonly UltronContext context;

        public Head2HeadService(UltronContext context)
        {
            this.context = context;
        }
    }
}