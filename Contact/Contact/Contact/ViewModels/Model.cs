using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.ViewModels
{
	public class Model
	{
#region Variebl
		private  string  _name;
		private  string  _frstename;
		private int? _age;
        private string _birthDate;
        private string _fhoneNamber;
        private string _Imealing_Addres;
#endregion

        #region Propertis
        public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		public string Frstename
		{
			get { return _frstename; }
			set { _frstename = value; }
		}
		public int? Age
		{
			get { return _age; }
			set { _age = value; }
		}
        public string BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public string FhoneNamber
        {
            get { return _fhoneNamber; }
            set { _fhoneNamber = value; }
        }
        public string Imealing_Addres
        {
            get { return _Imealing_Addres; }
            set { _Imealing_Addres = value; }
        }
        
      #endregion
    }
}
