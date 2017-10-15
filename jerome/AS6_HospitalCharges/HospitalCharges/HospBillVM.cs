using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HospitalCharges
{
    class HospBillVM : INotifyPropertyChanged
    {
        const decimal DAY_RATE = 350;
        
        private decimal days;
        public decimal Days
        {
            get { return days; }
            set { days = value; NotifyPropertyChanged(); }
        }

        private decimal meds;
        public decimal Meds
        {
            get { return meds; }
            set { meds = value; NotifyPropertyChanged(); }
        }

        private decimal surgery;
        public decimal Surgery
        {
            get { return surgery; }
            set { surgery = value; NotifyPropertyChanged(); }
        }

        private decimal lab;
        public decimal Lab
        {
            get { return lab; }
            set { lab = value; NotifyPropertyChanged(); }
        }

        private decimal rehab;
        public decimal Rehab
        {
            get { return rehab; }
            set { rehab = value; NotifyPropertyChanged(); }
        }

        private decimal baseCharges;
        public decimal BaseCharges
        {
            get { return baseCharges; }
            set { baseCharges = value; NotifyPropertyChanged(); }
        }

        public void CalcStayCharges()
        {
            BaseCharges = Days * DAY_RATE;
        }

        private decimal miscCharges;
        public decimal MiscCharges
        {
            get { return miscCharges; }
            set { miscCharges = value; NotifyPropertyChanged(); }
        }

        public void CalcMiscCharges()
        {
            MiscCharges = Meds + Surgery + Lab + Rehab;
        }

        private decimal totalCharges;
        public decimal TotalCharges
        {
            get { return totalCharges; }
            set { totalCharges = value; NotifyPropertyChanged(); }
        }

        public void CalcTotalCharges()
        {
            TotalCharges = BaseCharges + MiscCharges;
        }

        private DateTime admDate;
        public DateTime AdmDate
        {
            get { return admDate; }
            set { admDate = value; NotifyPropertyChanged(); }
        }

        public void SetAdmDate()
        {
            int admDays = Convert.ToInt32(Days) * -1;
            AdmDate = DateTime.Today.AddDays(admDays);
        }

        #region
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
