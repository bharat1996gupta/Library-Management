   M S B A M L   `   `   `  ����L  HLibraryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LibraryManagementLibraryManagement  5   	   "    LibraryManagement.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:LibraryManagement     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	       #  Body_Content_DataGrid_Centering �� 
TargetType*  $System.Windows.Controls.DataGridCell �� Property �� Value �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%  &	        '  �     �� 5
   
   "  5   	   .�5      ��  � �� 5      �� 5      "  6&   .R�5      � #��z��6   .+�5      �� $��Center=�6/   5      5      5      5      �� 5   
   "  6   .�5      ��  � ��$ Center=�6E   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5       $��* �6   �� 5!      $��* �6   �� 5"      $��* �6   �� 5#      $��* �6   �� 5$      $��* �6   �� 5%      $��* �6   �� 5&      $��* �6   �� 5'      $��* �6   �� 5(      $��* �6   �� 5)      $��50 �6    � RowDefinitions 5.   
   �� 5/      $��50 �6   �� 50      $��* �6   �� 51      $��* �6   �� 52      $��* �6   �� 53      $��* �6   �� 54      $��* �6   �� 55      $��* �6   �� 56      $��* �6   �� 57      $��* �6   �� 58      $��* �6   �� 59      $��* �6   �� 5:      $��* �6   �� 5;      $��* �6   �� 5<      $��* �6   �� 5=      $��50 �6   .+�5B   
   &   System.Windows.Controls.DataGrid  -   5        $��LibraryMembersDataGrid��5B      $��1��5C      $��1��5D      $��1��5E      $��6��5F         AutoGenerateColumns .  	   	CellStyle#	 [  5H      
   Columns
 5I      0  *System.Windows.Controls.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn   Header$ Members��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5K   %      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 5M   %   �� *Name+5O        5S   
   -   5        $��LibraryMediaDataGrid��5S      $��1��5T      $��3��5U      $��7��5V      $��9��5W       .  #	 [  5Y      
 5Z        5[      $ Serial��6%    . $
 0.4* 5]   %    5^   %   �� *SerialNumber+  5_      $ Title��6%    . $
 1.4* 5a   %    5b   %   �� *Title+  5c      $ 
Media Type��6%    . $
 0.7* 5e   %    5f   %   �� *	MediaType+4  .System.Windows.Controls.DataGridCheckBoxColumn  5l      $ 	Available��6)    . $
 0.6* 5n   %    5o   %   �� *BorrowedOrAvailable+  5p      $ Borrower��6%    . $
 0.5* 5r   %    5s   %   �� *BorrowerName+5u      �� 5y   
   -   5        $��
LentButton��5y      $��
Lent Media��5z      $��2��5{      $��12��5|      $��2��5}      $��2��5~      5      �� 5�   
   -   5        $��ReturnButton��5�      $��Return Media��5�      $��7��5�      $��12��5�      $��2��5�      $��2��5�      5�      5�      5�      