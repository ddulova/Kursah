   M S B A M L   `   `   `  ����A  =kd2020, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:kd2020.Pageskd2020.Pages  5          kd2020.Pages.AddRole   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:kd2020.Pages     5      -   5          N� Title$  AddRole��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Номер мастера��6   6+   �� 5   
   $��
Логин��6   $��1��6!   60   �� 5   
   $��Пароль��6   $��2��6"   61   �� 5   
   $��Роль��6   $��3��6    6/   �� 5   
   -   5        $��IDmas��5      $��1��6<   $	��595��6L   $
��Left=�6X   $��	5,30,0,37q�6s   $��23��6�   ��6   �� *
masters_id+6�   �� 5   
   $��1��6*   $	��595��6:   $��1��6F   $
��Left=�6S   $��	5,30,0,37q�6n   $��23��6�   ��6   �� *login+6�   �� 5   
    �� 	MaxLength$ 50��6.   $	��595��6=   $��1��6I   $��2��6Y   $
��Left=�6f   $��	5,30,0,37q�6�   $��23��6�   ��6   �� *
password+6�   �� 5   
   $ 50��6+   $	��595��6:   $��1��6F   $��3��6V   $
��Left=�6c   $��	5,30,0,37q�6~   $��23��6�   ��6   �� *role1+6�   �� 5    
   -   5        $��BtnSave��5    F   $��Сохранить��6   $��2��6%   $��4��69   5!      5#      5$      