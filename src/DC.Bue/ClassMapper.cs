using System.Linq;

namespace DC.Bue
{
    public class ClassMapper : BaseMapper
    {
        private string buildClass;

        public string Class
        {
            get
            {
                if (dirty)
                {
                    //组合Class，但只组合具有值的Class
                    if (rules != null && listRules != null)
                    {
                        buildClass = string.Join(" ", GetValidRules().Concat(GetValidListRules()));
                    }
                    else if (rules != null)
                    {
                        buildClass = string.Join(" ", GetValidRules());
                    }
                    else if (listRules != null)
                    {
                        buildClass = string.Join(" ", GetValidListRules());
                    }
                    else
                    {
                        buildClass = null;
                    }

                    dirty = false;
                }

                return buildClass;
            }
        }
    }
}
