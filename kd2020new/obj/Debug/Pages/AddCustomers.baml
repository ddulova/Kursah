   M S B A M L   `   `   `  ����A  =kd2020, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:kd2020.Pageskd2020.Pages  5          kd2020.Pages.AddCustomers   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:kd2020.Pages     5        N� Title$  AddCustomers��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Номер машины��6   6*   �� 5   
   $��Номер клиента��6   $��1��6)   68   �� 5   
   $��Дата покупки��6   $��2��6(   67   �� 5   
   $��Номер заказа��6   $��3��6(   67   �� 5   
   $��1��6-   $	��595��6=   $
��Left=�6I   $��	5,30,0,37q�6d   $��23��6w   ��6   �� *	cars_id+6�   �� 5   
   $��1��6.   $	��595��6>   $��1��6J   $
��Left=�6W   $��	5,30,0,37q�6r   $��23��6�   ��6   �� *	owners_id+6�   �� 5   
    �� 	MaxLength$ 50��66   $	��595��6E   $��1��6Q   $��2��6a   $
��Left=�6n   $��	5,30,0,37q�6�   $��23��6�   ��6   �� *date_of_purchase+6�   �� 5   
   $ 50��60   $	��595��6?   $��1��6K   $��3��6[   $
��Left=�6h   $��	5,30,0,37q�6�   $��23��6�   ��6   �� *	orders_id+6�   �� 5    
   -   5        $��BtnSave��5    F   $��Сохранить��6   $��2��6%   $��4��69   5!      5"      5#      