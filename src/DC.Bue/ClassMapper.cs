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
                    //组合样式类，但只组合具有值的样式类
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
