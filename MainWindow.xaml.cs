using System.Data.Common;
using System.Windows;
using System.Windows.Controls.Primitives;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace MansionMapEditor
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MySqlConnection connection;

        bool initializingComponent;

        public MainWindow()
        {
            initializingComponent = true;

            InitializeComponent();

            initializingComponent = false;

            ShowCharactersOrRaces(true);

            ServerText.Text = "localhost";
            PortText.Text = "3307";
            DBText.Text = "mansion";
            UserText.Text = "root";
            PassText.Text = "";

            ConnectButton.IsEnabled = true;
            DisconnectButton.IsEnabled = false;

        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string conn = "server=" + ServerText.Text + ";" + "uid=" + UserText.Text + ";" 
                              + "port=" + PortText.Text + ";" + "database=" + DBText.Text;

                connection = new MySqlConnection(conn);
                connection.Open();
                MessageBox.Show("Database conected");
                ConnectButton.IsEnabled = false;
                DisconnectButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            // Crea la conexión con la base de datos utilizando los valores
            // de los campos como server o user para construir el connection string

        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // Cierra la conexión con la base de datos
                connection.Close();
                MessageBox.Show("Database disconected");
                ConnectButton.IsEnabled = true;
                DisconnectButton.IsEnabled = false;

            }
            catch(Exception ex)
            {
                ShowError(ex);
            }
        }

        private void InitializeButton_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                // Volver a crear las tablas de la base de datos, eliminando las
                // tablas anteriores

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "DROP TABLE characters";
                try { command.ExecuteNonQuery(); } catch { MessageBox.Show("no character table creating one"); }
                command.CommandText = "DROP TABLE races";
                try { command.ExecuteNonQuery(); } catch { MessageBox.Show("no races table creating one"); }

                command.CommandText = "CREATE TABLE races(ID INT NOT NULL PRIMARY KEY, NAME VARCHAR(45) NOT NULL, MP INT NOT NULL, PP INT NOT NULL)";
                command.ExecuteNonQuery();
                command.CommandText = "CREATE TABLE characters(ID INT NOT NULL PRIMARY KEY, NAME VARCHAR(45) NOT NULL, IH INT NOT NULL, GENDER VARCHAR(45) NOT NULL, RACES INT NULL)";
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                ShowError(ex);
            }
        }

        private void CharacterFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM characters WHERE ID=" + TeamIdText.Text + ";";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ModelText.Text = reader.GetString(1);
                    if (reader.GetInt32(2) == 0)
                    {
                        HeroCheckbox.IsChecked = true;
                    }
                    else
                    {
                        HeroCheckbox.IsChecked = false;
                    }

                    if (reader.GetString(3) == "Female")
                    {
                        CharacterGenderComboBox.Text = "Female";
                    }
                    else if (reader.GetString(3) == "Male")
                    {
                        CharacterGenderComboBox.Text = "Male";
                    }
                    else
                    {
                        CharacterGenderComboBox.Text = "Other";
                    }
                    TeamText.Text = (reader.IsDBNull(4)? "" : "" + reader.GetInt32(4));
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                ShowError(ex);
            }
        }

        private string autoAdd(string s)
        { 
            return "'" + s + "'";
        }

        private void CharacterAddButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // Añadir un nuevo personaje con los valores que el diseñador tenga
                // puestos en los campos
                int statusBool;
                MySqlCommand command = connection.CreateCommand();
                if (HeroCheckbox.IsChecked == true)
                {
                    statusBool = 0;
                }
                else
                {
                    statusBool = 1;
                }

                command.CommandText = "INSERT INTO characters VALUES(" + CharacterIdText.Text + "," +
                                        autoAdd(ModelText.Text) + "," +
                                        statusBool + "," +
                                        autoAdd(CharacterGenderComboBox.Text) + "," +
                                        (TeamText.Text.Trim().Length == 0? "NULL" : TeamText.Text) + ");";
                command.ExecuteNonQuery();

                UpdateCharacterList();

            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void CharacterModify_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Actualizar el personaje con el id que tenga puesto el diseñador
                // con lo que tenga puesto en el resto de campos
                //UPDATE races set name = 1 WHERE id = 1;
                int statusBool;
                MySqlCommand command = connection.CreateCommand();
                if (HeroCheckbox.IsChecked == true)
                {
                    statusBool = 0;
                }
                else
                {
                    statusBool = 1;
                }
                command.CommandText = "UPDATE characters set NAME=" + autoAdd(ModelText.Text) + "," +
                                      "IH=" + statusBool + "," +
                                      "GENDER=" + autoAdd(CharacterGenderComboBox.Text) + "," +
                                      "RACES=" + TeamText.Text +
                                      " WHERE ID=" + CharacterIdText.Text + ";";
                command.ExecuteNonQuery();


                UpdateCharacterList();

            }
            catch(Exception ex)
            {
                ShowError(ex);
            }
        }

        private void CharacterDeleteButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // Eliminar el personaje con el id que tenga puesto el diseñador
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM characters WHERE ID=" + CharacterIdText.Text;
                command.ExecuteNonQuery();

               UpdateCharacterList();

            }
            catch(Exception ex)
            {
                ShowError(ex);
            }
        }

        private void CharacterListUpdate_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // Actualizar la lista de personajes

                //SELECT* FROM characters;

                string text = "";
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM characters;";
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    text += reader.GetString(1) + " " + reader.GetBoolean(2) + " " + reader.GetString(3) + (reader.IsDBNull(4)? "" : "" + reader.GetInt32(4)) + "\n";
                }
                CharacterListText.Text += text;
                reader.Close();

                UpdateCharacterList();
            }
            catch(Exception ex)
            {
                ShowError(ex);
            }
        }

        void UpdateCharacterList()
        {
            // Actualizar la lista de personajes
        }

        private void EditCharactersRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(initializingComponent) { return; }

            ShowCharactersOrRaces(true);
        }

        private void EditRacesRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(initializingComponent) { return; }

            ShowCharactersOrRaces(false);
        }

        void ShowCharactersOrRaces(bool characters)
        {
            CharactersCanvas.Visibility = Visibility.Collapsed;
            RacesCanvas.Visibility = Visibility.Collapsed;

            if(characters)
            {
                CharactersCanvas.Visibility = Visibility.Visible;
            }
            else
            {
                RacesCanvas.Visibility = Visibility.Visible;
            }
        }

        private void RaceFind_Click(object sender, RoutedEventArgs e)
        {
            //SELECT * FROM races WHERE ID=;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM races WHERE ID=" + TeamIdText.Text + ";";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TeamName.Text = reader.GetString(1);
                RaceMagicText.Text = Convert.ToString(reader.GetInt32(2));
                RacePhysicText.Text = Convert.ToString(reader.GetInt32(3));
            }
            reader.Close();
        }

        private void RaceAdd_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO races VALUES(" + TeamIdText.Text + "," +
                                  autoAdd(TeamName.Text) + "," +
                                  RaceMagicText.Text + "," +
                                  RacePhysicText.Text + ");";
            command.ExecuteNonQuery();
                                  
        }

        private void RaceModify_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE races set NAME=" + autoAdd(TeamName.Text) + "," +
                                  "MP=" + RaceMagicText.Text + "," +
                                  "PP=" + RacePhysicText.Text +
                                  " WHERE id =" + TeamIdText.Text + ";";
            command.ExecuteNonQuery();
        }

        private void RaceDelete_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM races WHERE ID=" + TeamIdText.Text;
            command.ExecuteNonQuery();
        }

        private void RaceListUpdate_Click(object sender, RoutedEventArgs e)
        {
            string text = "";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM races;";
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                text += reader.GetString(1) + " " + reader.GetInt32(2) + " " + reader.GetInt32(3) + "\n";
            }
            TeamListText.Text += text;
            reader.Close();
        }

        private void ShowError(Exception e)
        {
            MessageBox.Show("Error: " + e.Message);
        }

        private void ShowMessage(string text)
        {
            MessageBox.Show(text);
        }

        private string Quote(string s)
        {
            return "'" + s + "'";
        }
    }
}