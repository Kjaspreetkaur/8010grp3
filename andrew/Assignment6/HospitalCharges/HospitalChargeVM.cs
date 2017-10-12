/** Hospital Charges A6 GRP3
 * Archit A.    8024168
 * Parthik M.   8050213
 * Jerome S.    8055907
 * Jaspreet K.  8051666
 * Andrew H.    8113730
 * Bhumi S.     8022584
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HospitalCharges
{
    public class HospitalChargeVM : INotifyPropertyChanged
    {
        const decimal DAILY_BASE_CHARGE = 350.00m;
        private int _dayAmnt;
        private decimal _medicationAmnt;
        private decimal _surgicalAmnt;
        private decimal _labFeeAmnt;
        private decimal _physRehabAmnt;
        private decimal _stayAmnt;
        private decimal _miscAmnt;
        private decimal _totalAmnt;

        //Calculation Variables
        public int DayAmnt
        {
            get
            {
                return _dayAmnt;
            }
            set
            {
                _dayAmnt = value;
                Calculate();
                NotifyPropertyChanged();
            }
        }
        public decimal MedicationAmnt
        {
            get
            {
                return _medicationAmnt;
            }
            set
            {
                _medicationAmnt = value;
                Calculate();
                NotifyPropertyChanged();
            }
        }
        public decimal SurgicalAmnt
        {
            get
            {
                return _surgicalAmnt;
            }
            set
            {
                _surgicalAmnt = value;
                Calculate();
                NotifyPropertyChanged();
            }
        }
        public decimal LabFeeAmnt
        {
            get
            {
                return _labFeeAmnt;
            }
            set
            {
                _labFeeAmnt = value;
                Calculate();
                NotifyPropertyChanged();
            }
        }
        public decimal PhysRehabAmnt
        {
            get
            {
                return _physRehabAmnt;
            }
            set
            {
                _physRehabAmnt = value;
                Calculate();
                NotifyPropertyChanged();
            }
        }

        //Display Total Variables
        public decimal StayAmnt
        {
            get
            {
                return _stayAmnt;
            }
            set
            {
                _stayAmnt = value;
                NotifyPropertyChanged();
            }
        }
        public decimal MiscAmnt
        {
            get
            {
                return _miscAmnt;
            }
            set
            {
                _miscAmnt = value;
                NotifyPropertyChanged();
            }
        }
        public decimal TotalAmnt
        {
            get
            {
                return _totalAmnt;
            }
            set
            {
                _totalAmnt = value;
                NotifyPropertyChanged();
            }
        }

        public void Reset()
        {
            DayAmnt = 0;
            MedicationAmnt = 0;
            SurgicalAmnt = 0;
            LabFeeAmnt = 0;
            PhysRehabAmnt = 0;
            MiscAmnt = 0;
            TotalAmnt = 0;
            MiscAmnt = 0;
        }

        public decimal CalcStayCharges()
        {
            return DAILY_BASE_CHARGE*DayAmnt;
        }

        public decimal CalcMiscCharges()
        {
            return (MedicationAmnt + SurgicalAmnt + LabFeeAmnt + PhysRehabAmnt);
        }

        public decimal CalcTotalCharges()
        {
            return CalcStayCharges() + CalcMiscCharges();
        }

        public void Calculate()
        {
            StayAmnt = CalcStayCharges();
            MiscAmnt = CalcMiscCharges();
            TotalAmnt = CalcTotalCharges();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
