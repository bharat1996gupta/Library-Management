using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Library library = new Library();
        public MainWindow()
        {
            InitializeComponent();
            LibraryMembersDataGrid.ItemsSource = library.libraryMembers;
            LibraryMediaDataGrid.ItemsSource = library.medias;
        }

        /// <summary>
        /// Method to give borrower the items that they want and are available as well.
        /// </summary>
        /// <param name="listOfMediaToBorrow"> Contains list of items that library member wants to borrow.</param>
        /// <param name="borrower">Contains name of library member who is borrowing.</param>
        private void BorrowItems(IList listOfMediaToBorrow, LibraryMember borrower)
        {
            for (int i = 0; i < listOfMediaToBorrow.Count; i++)
            {
                if (((Media)listOfMediaToBorrow[i]).BorrowedOrAvailable)
                {
                    ((Media)listOfMediaToBorrow[i]).BorrowedOrAvailable = false;
                    ((Media)listOfMediaToBorrow[i]).BorrowerName = borrower.Name;
                }
            }
        }


        /// <summary>
        /// Refreshes the library media grid.
        /// </summary>
        private void RefreshMediaGrid()
        {
            LibraryMediaDataGrid.ItemsSource = null;
            LibraryMediaDataGrid.ItemsSource = library.medias;
        }

        /// <summary>
        /// Checks and tells which items are currently available in library to borrow out of selected ones.
        /// </summary>
        /// <param name="listOfMediaToBorrow">Contains list of items that library member wants to borrow.</param>
        /// <param name="namesOfUnavailableMedia">Contains string for list of media unavailable out of selected ones.</param>
        /// <param name="numberOfUnavailableMedia">Contains number of media unavailable out of selected ones.</param>
        /// <param name="namesOfAvailableMedia">Contains string for list of media available out of selected ones.</param>
        /// <param name="numberOfAvailableMedia">Contains number of media available out of selected ones.</param>
        private void CheckAvailabilityOfSelectedItems(IList listOfMediaToBorrow, out string namesOfUnavailableMedia,
                                                        out int numberOfUnavailableMedia, out string namesOfAvailableMedia, out int numberOfAvailableMedia)
        {
            namesOfUnavailableMedia = "";
            numberOfUnavailableMedia = 0;
            namesOfAvailableMedia = "";
            numberOfAvailableMedia = 0;
            for (int i = 0; i < listOfMediaToBorrow.Count; i++)
            {
                if (!(((Media)listOfMediaToBorrow[i]).BorrowedOrAvailable))
                {
                    numberOfUnavailableMedia++;
                    namesOfUnavailableMedia += " \n " + ((Media)listOfMediaToBorrow[i]).Title;
                }
                else
                {
                    numberOfAvailableMedia++;
                    namesOfAvailableMedia += " \n " + ((Media)listOfMediaToBorrow[i]).Title;
                }
            }
            namesOfUnavailableMedia += numberOfUnavailableMedia > 1 ? " are " : " is ";
            namesOfAvailableMedia += numberOfAvailableMedia > 1 ? " are " : " is ";
        }

        private bool CheckItemsSelected(LibraryMember member, IList memberList, IList mediaList)
        {
            // check whether any member has been selected or not and whether any item has been selected or not before trying to lend anything
            if (member == null)
            {
                MessageBox.Show("No library member is chosen to lend media.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (memberList.Count > 1)
            {
                MessageBox.Show("Only one library member can lend media at one turn.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (mediaList.Count == 0)
            {
                MessageBox.Show("At least one media must be selected to lend.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                return true;

            return false;
        }

        private void LentButton_Click(object sender, RoutedEventArgs e)
        {

            // Getting borrower and borrowed item(s)
            LibraryMember borrower = (LibraryMember)LibraryMembersDataGrid.SelectedItem;
            IList checkBorrowerCount = LibraryMembersDataGrid.SelectedItems; // just to make sure that user doesn't select more than one library members
            IList listOfMediaToBorrow = LibraryMediaDataGrid.SelectedItems;

            if (!CheckItemsSelected(borrower, checkBorrowerCount, listOfMediaToBorrow))
                return;


            string namesOfUnavailableMedia;
            int numberOfUnavailableMedia;
            string namesOfAvailableMedia;
            int numberOfAvailableMedia;

            // Traverse through items to see which can and cannot be borrowed
            CheckAvailabilityOfSelectedItems(listOfMediaToBorrow, out namesOfUnavailableMedia, out numberOfUnavailableMedia,
                                                out namesOfAvailableMedia, out numberOfAvailableMedia);

            if (numberOfAvailableMedia == listOfMediaToBorrow.Count)
            {
                // inside here means that all selected items can be borrowed
                BorrowItems(listOfMediaToBorrow, borrower);
            }
            else if (numberOfUnavailableMedia == listOfMediaToBorrow.Count)
            {
                // inside here means that nothing is available 
                MessageBox.Show("Sorry" + namesOfUnavailableMedia + "not available right now for you to borrow.", "ERROR!!!",
                                    MessageBoxButton.YesNo, MessageBoxImage.Error);
            }
            else if (MessageBox.Show("Sorry, following are not available right now.\n" + namesOfUnavailableMedia + " \n\n But following are available right now\n" + namesOfAvailableMedia
                                       + "\n\n Click 'Yes' if you wish to borrow the available media and" +
                                       " 'No' if you don't wanna borrow anything.", "ERROR!!!", MessageBoxButton.YesNo,
                                       MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // inside here means that some item(s) cannot be lend but user borrowed the available ones
                BorrowItems(listOfMediaToBorrow, borrower);
            }
            else
            {
                // inside here means that user took nothing
                MessageBox.Show("You did not lent anything at all.", "Final Decision", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            // refresh library media grid
            RefreshMediaGrid();

        }


        /// <summary>
        /// Method to return items lent by library member.
        /// </summary>
        /// <param name="listOfMediaToReturn"> Contains list of items that library member wants to borrow.</param>
        private void ReturnItems(IList listOfMediaToReturn, LibraryMember returner)
        {
            for (int i = 0; i < listOfMediaToReturn.Count; i++)
            {
                if (!((Media)listOfMediaToReturn[i]).BorrowedOrAvailable && returner.Name.Equals(((Media)listOfMediaToReturn[i]).BorrowerName))
                {
                    ((Media)listOfMediaToReturn[i]).BorrowedOrAvailable = true;
                    ((Media)listOfMediaToReturn[i]).BorrowerName = "";
                }
            }
        }


        private void CheckReturnableMedia(IList listOfMediaToReturn, LibraryMember returner,
                                            out int numberOfWrongReturningMedia, out string namesOfWrongReturningMedia,
                                            out int numberOfRightReturningMedia, out string namesOfRightReturningMedia)
        {
            numberOfWrongReturningMedia = 0;
            namesOfWrongReturningMedia = "";
            numberOfRightReturningMedia = 0;
            namesOfRightReturningMedia = "";

            for (int i = 0; i < listOfMediaToReturn.Count; i++)
            {
                if (returner.Name.Equals(((Media)listOfMediaToReturn[i]).BorrowerName))
                {
                    numberOfRightReturningMedia++;
                    namesOfRightReturningMedia += " \n " + ((Media)listOfMediaToReturn[i]).Title;
                }
                else
                {
                    numberOfWrongReturningMedia++;
                    namesOfWrongReturningMedia += " \n " + ((Media)listOfMediaToReturn[i]).Title;
                }
            }
            namesOfWrongReturningMedia += numberOfWrongReturningMedia > 1 ? " are " : " is ";
            namesOfRightReturningMedia += numberOfRightReturningMedia > 1 ? " are " : " is ";
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            // Getting borrower and borrowed item(s)
            LibraryMember returner = (LibraryMember)LibraryMembersDataGrid.SelectedItem;
            IList checkReturnerCount = LibraryMembersDataGrid.SelectedItems; // just to make sure that user doesn't select more than one library members
            IList listOfMediaToReturn = LibraryMediaDataGrid.SelectedItems;

            // check whether any member has been selected or not and whether any item has been selected or not before trying to return anything
            if (returner == null)
            {
                MessageBox.Show("No library member is chosen to return media.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (checkReturnerCount.Count > 1)
            {
                MessageBox.Show("Only one library member can return media at one turn.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (listOfMediaToReturn.Count == 0)
            {
                MessageBox.Show("At least one media must be selected to return.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                int numberOfWrongReturningMedia;
                string namesOfWrongReturningMedia;
                int numberOfRightReturningMedia;
                string namesOfRightReturningMedia;

                // Traverse through items to see which can and cannot be returned
                CheckReturnableMedia(listOfMediaToReturn, returner,
                                                out numberOfWrongReturningMedia, out namesOfWrongReturningMedia,
                                                out numberOfRightReturningMedia, out namesOfRightReturningMedia);

                if (numberOfWrongReturningMedia == 0)
                {
                    // inside here means that all selected items can be returned
                    ReturnItems(listOfMediaToReturn, returner);
                }
                else if (numberOfRightReturningMedia == 0)
                {
                    // inside here means that nothing is returnable 
                    MessageBox.Show("Sorry" + namesOfWrongReturningMedia + "not issued under your name.", "ERROR!!!",
                                        MessageBoxButton.YesNo, MessageBoxImage.Error);
                }
                else if (MessageBox.Show("Sorry, following media doesn't belong to you : \n" + namesOfWrongReturningMedia + "\n\n But, following are issued by you\n" + namesOfRightReturningMedia
                                           + "\n\n Click 'Yes' if you wish to return the returnable media and" +
                                           " 'No' if you don't wanna return anything.", "ERROR!!!", MessageBoxButton.YesNo,
                                           MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    // inside here means that some item(s) cannot be returned
                    ReturnItems(listOfMediaToReturn, returner);
                }
                else
                {
                    MessageBox.Show("You did not return anything at all.", "Final Decision", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                // refresh library media grid
                RefreshMediaGrid();
            }
        }
    }
}
