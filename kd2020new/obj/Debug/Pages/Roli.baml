   M S B A M L   `   `   `  ����A  =kd2020, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:kd2020.Pageskd2020.Pages  5          kd2020.Pages.Roli   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:kd2020.Pages     5      -   5          N� Title$
  Roli��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��165* �6   �� 5      $	��45* �6   �� 5      $	��19* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	DgridRoli��5         AutoGenerateColumns .     
IsReadOnly . $��	0,0,0,6.6q�6T      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер мастера��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *
masters_id+6j     5      $ 
Логин��6%   $ * 6O    64   �� *login+6[     5      $ Пароль��6%   $ * 6S    65   �� *
password+6_     5      $ Роль��6%   $ * 6N    63   �� *role1+6Z   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 auto 6)   	   CellTemplate	 5      �� 5      .R�5      �� $��BtnEdit��6=   -   5        $ ��Редактировать��5   %   5      5      5      5!      �� 5"   
   -   5        $��BtnAdd��5"   L   $��Добавить��6   $��1��6$   $
��Left=�61   6q   �� 5#   
   -   5        $��	BtnDelete��5#   L   $��Удалить��6   $��1��6#   $��Right=�60   6w   5$      5%      