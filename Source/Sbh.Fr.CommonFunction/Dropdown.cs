using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sbh.Fr.CommonFunction
{
    public class Dropdown
    {
        public static SelectList GetNullList()
        {
            List<string> list = new List<string>();
            list.Add("Select :");
            SelectList selectList = new SelectList(list);
            return selectList;
        }

        public static SelectList GetGenderList()
        {
            List<CUSTOM> genderList = new List<CUSTOM>();
            string[] genders = new string[] { "L", "P" };
            for (int i = 0; i < genders.Count(); i++)
            {
                CUSTOM gender = new CUSTOM();
                gender.TEXT = genders[i];
                gender.VALUE = genders[i];
                genderList.Add(gender);
            }
            SelectList selectList = new SelectList(genderList, "VALUE", "TEXT");
            return selectList;
        }

        public static SelectList GetTypeSosmedList()
        {
            List<CUSTOM> typeSosmedList = new List<CUSTOM>();
            string[] typeSosmeds = new string[] { "Social", "Embed" };
            for (int i = 0; i < typeSosmeds.Count(); i++)
            {
                CUSTOM typeSosmed = new CUSTOM();
                typeSosmed.TEXT = typeSosmeds[i];
                typeSosmed.VALUE = typeSosmeds[i];
                typeSosmedList.Add(typeSosmed);
            }
            SelectList selectList = new SelectList(typeSosmedList, "VALUE", "TEXT");
            return selectList;
        }

        public static SelectList GetClassActiveList()
        {
            List<CUSTOM> classActiveList = new List<CUSTOM>();
            string[] classActives = new string[] { "active", "inactive" };
            for (int i = 0; i < classActives.Count(); i++)
            {
                CUSTOM classActive = new CUSTOM();
                classActive.TEXT = classActives[i];
                classActive.VALUE = classActives[i];
                classActiveList.Add(classActive);
            }
            SelectList selectList = new SelectList(classActiveList, "VALUE", "TEXT");
            return selectList;
        }

        public static SelectList GetTemplateList()
        {
            List<CUSTOM> classActiveList = new List<CUSTOM>();
            string[] classActives = new string[] { "1", "2", "3", "4" };
            for (int i = 0; i < classActives.Count(); i++)
            {
                CUSTOM classActive = new CUSTOM();
                classActive.TEXT = classActives[i];
                classActive.VALUE = classActives[i];
                classActiveList.Add(classActive);
            }
            SelectList selectList = new SelectList(classActiveList, "VALUE", "TEXT");
            return selectList;
        }

        public static SelectList GetTrueFalse()
        {
            List<CUSTOM> classActiveList = new List<CUSTOM>();
            string[] classActives = new string[] { "False", "True" };
            for (int i = 0; i < classActives.Count(); i++)
            {
                CUSTOM classActive = new CUSTOM();
                classActive.TEXT = classActives[i];
                classActive.VALUE = i.ToString();
                classActiveList.Add(classActive);
            }
            SelectList selectList = new SelectList(classActiveList, "VALUE", "TEXT");
            return selectList;
        }

        public static SelectList GetClassButtonList()
        {
            List<CUSTOM> classButtonList = new List<CUSTOM>();
            string[] classButtons = new string[] { "default", "primary", "success", "warning", "danger" };
            for (int i = 0; i < classButtons.Count(); i++)
            {
                CUSTOM classButton = new CUSTOM();
                classButton.TEXT = classButtons[i];
                classButton.VALUE = classButtons[i];
                classButtonList.Add(classButton);
            }
            SelectList selectList = new SelectList(classButtonList, "VALUE", "TEXT");
            return selectList;
        }

        public static SelectList GetPaymentType()
        {
            List<CUSTOM> classButtonList = new List<CUSTOM>();
            string[] classButtons = new string[] { "Transfer", "Cash" };
            for (int i = 0; i < classButtons.Count(); i++)
            {
                CUSTOM classButton = new CUSTOM();
                classButton.TEXT = classButtons[i];
                classButton.VALUE = classButtons[i];
                classButtonList.Add(classButton);
            }
            SelectList selectList = new SelectList(classButtonList, "VALUE", "TEXT");
            return selectList;
        }
    }

    internal class CUSTOM
    {
        public string TEXT { get; set; }
        public string VALUE { get; set; }
    }
}
