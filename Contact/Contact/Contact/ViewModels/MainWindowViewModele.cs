using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using Contact.MVVM;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Data.Entity;
using System.Data.Entity.Migrations;


namespace Contact.ViewModels
{
    public class MainWindowViewModele : INotifyPropertyChanged
    {
        #region Variables
        Model _model;
        ObservableCollection<Model> _models;
        ObservableCollection<Model> _models1;
        MyDatabaseContactEntities dbcontact;

        #endregion

        #region Constructr
        public MainWindowViewModele()
        {

            AddCommand = (new RelayCommand(Add, CanAdd));
            AddCommand_View_all_contacts = (new RelayCommand(Add_View_all_contacts, CanAdd_View_all_contacts));
            AddCommand_Search_contacts_by_all_fields = (new RelayCommand(Add_Search_contacts_by_all_fields, CanAdd_Search_contacts_by_all_fields));
            AddCommand__Modify_update_a_contact = (new RelayCommand(Add_Modify_update_a_contact, CanAdd_Modify_update_a_contact));
            AddCommand_Delete_a_contact = (new RelayCommand(Delete_a_contact, Can_Delete_a_contact));
            dbcontact = new MyDatabaseContactEntities();
            _models = new ObservableCollection<Model>();
            _model = new Model();
            _models1 = new ObservableCollection<Model>();
        }
        #endregion

        #region Propertis
        public string Name
        {
            get { return Model.Name; }

            set
            {
                Model.Name = value;

                RaisePropertyChanged("Name");

            }
        }


        public string BirthDate
        {
            get { return Model.BirthDate; }

            set
            {
                Model.BirthDate = value;

                RaisePropertyChanged("BirthDate");

            }
        }
        public string FhoneNamber
        {
            get { return Model.FhoneNamber; }

            set
            {
                Model.FhoneNamber = value;

                RaisePropertyChanged("FhoneNamber");

            }
        }

        public string FrsteName
        {
            get { return Model.Frstename; }

            set
            {
                Model.Frstename = value;
                RaisePropertyChanged("FrsteName");

            }
        }


        public string Imealing_Addres
        {
            get { return Model.Imealing_Addres; }

            set
            {
                Model.Imealing_Addres = value;
                RaisePropertyChanged("Imealing_Addres");

            }
        }


        public int? Age
        {
            get { return Model.Age; }

            set
            {
                Model.Age = value;

                RaisePropertyChanged("Age");
            }
        }
        public Model Model
        {
            get { return _model; }
            set
            {
                _model = value;
                RaisePropertyChanged("Model");

            }
        }

        public ObservableCollection<Model> Models
        {
            get { return _models; }
            set
            {
                _models = value;
                RaisePropertyChanged("Models");

            }
        }

        public ObservableCollection<Model> Models1
        {
            get { return _models1; }
            set
            {
                _models = value;
                RaisePropertyChanged("Models");

            }
        }
        

        public ICommand AddCommand { get; }
        public ICommand AddCommand_View_all_contacts { get; }

        public ICommand AddCommand_Search_contacts_by_all_fields { get; }
        public ICommand AddCommand__Modify_update_a_contact { get; }
        public ICommand AddCommand_Delete_a_contact { get; }


        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Methods

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int count = 0;




        public void Delete_a_contact()
        {          
            List<Table> list = dbcontact.Tables.ToList();
            var id = 1;
            var deletecontact = dbcontact.Tables.Find(id);
            dbcontact.Entry(deletecontact).State = EntityState.Deleted;
            dbcontact.SaveChanges();
            Models.Add(Model);

            MessageBox.Show("Delete_a_contact");
        }

        public bool Can_Delete_a_contact()
        {


            //if ( Model.Frstename != null && Model.Name != null && Model.Age != null)

            return true;
            //return false;
        }


        public void Add_Modify_update_a_contact()
        {
           // MessageBox.Show("Add_Modify_update_a_contact");
         
            List<Table> list = dbcontact.Tables.ToList();

            var id = 1;
            var updatecontact = dbcontact.Tables.Find(id);
            if (updatecontact == null) return;
            updatecontact.Name = Name;
            dbcontact.Entry(updatecontact).State = EntityState.Modified;
            dbcontact.Tables.AddOrUpdate(updatecontact);
            dbcontact.SaveChanges();
            Models.Add(Model);
        }

        public bool CanAdd_Modify_update_a_contact()
        {


            //if ( Model.Frstename != null && Model.Name != null && Model.Age != null)

            return true;
            //return false;
        }
        public void Add_Search_contacts_by_all_fields()
        {

            MessageBox.Show("Search_contacts_by_all_fields");
        }

        public bool CanAdd_Search_contacts_by_all_fields()
        {


            //if ( Model.Frstename != null && Model.Name != null && Model.Age != null)

            return true;
            //return false;
        }

        public void Add_View_all_contacts()
        {
           
            List<Table> list = dbcontact.Tables.ToList();

            Model Model;

            foreach (var itm in list)

            {

                Model = new Model();
                Model.Name = itm.Name;
                Model.Frstename = itm.FrsteName;
                Model.Age = itm.Age;
                Model.BirthDate = itm.DithDate;
                Model.FhoneNamber = itm.DithDate;
                Model.Imealing_Addres = itm.ImealingAdd;
                Models.Add(Model);
            }
                  
        }

        public bool CanAdd_View_all_contacts()
        {


            //if ( Model.Frstename != null && Model.Name != null && Model.Age != null)

            return true;
            //return false;
        }

        public void Add()
        {         
          
            Random rnd = new Random();
            int Idrnd = rnd.Next(52);
            Table AddContact = new Table

            {
                Id = Idrnd,
                Name = Model.Name,
                FrsteName = Model.Frstename,
                Age = Convert.ToInt32(Model.Age),
                DithDate = Model.BirthDate,
                ImealingAdd = Model.Imealing_Addres,
                PhoneNumber = Convert.ToInt32(Model.FhoneNamber)

            };

            dbcontact.Tables.Add(AddContact);
            dbcontact.SaveChanges();
            Models.Add(Model);
        }
        

	public bool CanAdd()
		{
			

			//if ( Model.Frstename != null && Model.Name != null && Model.Age != null)

				return true;
			//return false;
		}
	}
		#endregion
	}

