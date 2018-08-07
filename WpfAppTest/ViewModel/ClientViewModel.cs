using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApplicationMVVM.Model;
using WpfApplicationMVVM.MVVM.ViewModel;

namespace WpfApplicationMVVM.ViewModel
{
    class ClientViewModel : ObservableCollection<Client>, INotifyPropertyChanged
    {

        #region Atributos
        private ClientViewModel clients;
        private int selectedIndex;

        private int id;
        private string name;
        private string lastName;
        private ICommand addClientCommand;
        private ICommand clearCommand;
        private ICommand deleteCommand;
        #endregion

        #region Propiedades
        public int SelectedIndexOfCollection
        {
            get
            {
                return selectedIndex;
            }//Fin de get.
            set
            {
                selectedIndex = value;
                OnPropertyChanged("SelectedIndexOfCollection");

                //Activa el evento OnPropertyChanged de los atributos para refrescar las propiedades segun el indice seleccionado.
                OnPropertyChanged("Id");
                OnPropertyChanged("Name");
                OnPropertyChanged("LastName");
            }//Fin de set.
        }//Fin de propiedad Name.

        public int Id
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Id;
                }//Fin de if.
                else
                {
                    return id;
                }//Fin de else.
            }//Fin de get.
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Id = value;
                }//Fin de if.
                else
                {
                    id = value;
                }//Fin de else.
                OnPropertyChanged("Id");
            }//Fin de set.
        }//Fin de propiedad Id.

        public string Name
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].Name;
                }//Fin de if.
                else
                {
                    return name;
                }//Fin de else. 
            }//Fin de get.
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].Name = value;
                }//Fin de if.
                else
                {
                    name = value;
                }//Fin de else.
                OnPropertyChanged("Name");
            }//Fin de set.
        }//Fin de propiedad Name.

        public string LastName
        {
            get
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    return this.Items[this.SelectedIndexOfCollection].LastName;
                }//Fin de if.
                else
                {
                    return lastName;
                }//Fin de else.
            }//Fin de get.
            set
            {
                if (this.SelectedIndexOfCollection > -1)
                {
                    this.Items[this.SelectedIndexOfCollection].LastName = value;
                }//Fin de if.
                else
                {
                    lastName = value;
                }//Fin de else.
                OnPropertyChanged("LastName");
            }//Fin de set.
        }//Fin de propiedad LastName.

        public ICommand AddClientCommand
        {
            get
            {
                return addClientCommand;
            }//Fin de get.
            set
            {
                addClientCommand = value;
            }//Fin de set.
        }//Fin de propiedad LastName.

        public ICommand ClearCommand
        {
            get
            {
                return clearCommand;
            }//Fin de get.
            set
            {
                clearCommand = value;
            }//Fin de set.
        }//Fin de propiedad LastName.
        #endregion
        public ICommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
            set
            {
                deleteCommand = value;
            }
        }

        #region Constructores
        public ClientViewModel()
        {
            
            
            Client vlClient1 = new Client();
            vlClient1.Id = 1;
            vlClient1.Name = "Pablo";
            vlClient1.LastName = "Gonzalez";
            this.Add(vlClient1);

            Client vlClient2 = new Client();
            vlClient2.Id = 2;
            vlClient2.Name = "Roberto";
            vlClient2.LastName = "Herrera";
            this.Add(vlClient2);

            Client vlClient3 = new Client();
            vlClient3.Id = 3;
            vlClient3.Name = "Anibal";
            vlClient3.LastName = "Salazar";
            this.Add(vlClient3);
            
            AddClientCommand = new CommandBase(param => this.AddClient());
            ClearCommand = new CommandBase(new Action<Object>(ClearClient));
            DeleteCommand = new CommandBase(new Action<object>(DeleteClient));
        }//Fin de constructor.
        #endregion

        #region Interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }//Fin de if.
        }//Fin de OnPropertyChanged.
        #endregion

        #region Metodos/Funcciones
        private void AddClient()
        {
            
            Client vlClient = new Client();
            vlClient.Id = Id;
            vlClient.Name = Name;
            vlClient.LastName = LastName;
            this.Add(vlClient);
        }//Fin de AddClient.

        private void ClearClient(object obj)
        {
            SelectedIndexOfCollection = -1;
            Id = 0;
            Name = "";
            LastName = "";
        }//Fin de AddClient.
        private void DeleteClient(object obj)
        {
            if (SelectedIndexOfCollection != -1)
            {
                
                this.RemoveItem(SelectedIndexOfCollection);
                this.CollectionChanged += this.OnCollectionChanged;
               
            }
        }

        private void LoadList()
        {
           
        }
        #endregion
        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ObservableCollection<object> obsSender;
            
            NotifyCollectionChangedAction action = e.Action;
        }
    }//Fin de clase.
}//Fin de namespace.