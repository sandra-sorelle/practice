using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffTable.Database
{
    partial class StaffTable1
    {
        public string FormatStartDate
        {
            get
            {
                if (StaffTableDateStart != null)
                {
                    DateTime date = (DateTime)StaffTableDateStart;
                    return date.ToShortDateString();
                }
                return string.Empty;
            }
        }
        public string TableColor
        {
            get
            {
                if (isSigned != null)
                {
                    if(isSigned == true)
                    {
                        return "#AB8CAC";
                    }
                    return "#F6F7FD";
                }
                return string.Empty;
            }
        }

        public string TableToolTip
        {
            get
            {
                if (isSigned != null)
                {
                    if (isSigned == true)
                    {
                        DateTime dateStart = (DateTime)StaffTableDateStart;
                        DateTime dateEnd = (DateTime)StaffTableDateEnd;
                        return $"Действующее штатное расписание от {dateStart.ToShortDateString()} до {dateEnd.ToShortDateString()}";
                    }
                    return "Неподписанное штатное расписание";
                }
                return string.Empty;
            }
        }
    }
    partial class getlinesinTable_Result
    {
        public decimal SumOfSalary
        {
            get
            {
                if (SalarySize != null && StaffUnits != null)
                {
                    return Math.Round((decimal)(SalarySize * StaffUnits), 2);
                }
                return 0;
            }
        }
        public decimal FormSalary
        {
            get
            {
                if (SalarySize != null )
                {
                    return Math.Round((decimal)SalarySize, 2);
                }
                return 0;
            }
        }
        public string NotesFormat
        {
            get
            {
                if (Notes == null || Notes ==String.Empty)
                {
                    return "-";
                }
                return Notes;
            }
        }
    }
}
