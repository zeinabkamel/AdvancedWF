

using System.Collections.Generic;

namespace AdvancedWf.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public class AllDropDownsViewModel
    {
        public List<DropDownViewModel> Specilization { get; set; }

        public List<DropDownViewModel> Cities { get; set; }

        public List<DropDownViewModel> Gender { get; set; }
        public List<DropDownViewModel> Postions { get; set; }

        public List<DropDownViewModel> Sections { get; set; }
        public List<DropDownViewModel> ActiveVolunteers { get; set; }

        public List<DropDownViewModel> StatusOfAchivements { get; set; }
        public List<DropDownViewModel> QualityOfAchivements { get; set; }



        public List<DropDownViewModel> SMSTemplate { get; set; }
        public List<DropDownViewModel> GetSMSTypes { get; set; }

        public List<DropDownViewModel> Programs { get; set; }
        public List<DropDownViewModel> Volunteers { get; set; }
    }
}
