   M S B A M L   `   `   `  ����A  =kd2020, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:kd2020kd2020  5          kd2020.AddOwners   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:kd2020     5        N� Title$  	AddOwners��5	      .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Номер клиента��6   6+   �� 5   
   $��Фамилия��6   $��1��6#   62   �� 5   
   $��Имя��6   $��2��6   6.   �� 5   
   $��Отчество��6   $��3��6$   63   �� 5    
   $!��Номер паспорта��6   $��4��6*   69   �� 5!   
   $��
Серия��6   $��5��6!   60   �� 5"   
   $��
Город��6   $��6��6!   60   �� 5#   
   $��Телефон��6   $��7��6#   62   �� 5&   
   -   5        $��IDowners��5&      $��1��6?   $	��600��6O   $
��Left=�6[   $��0,3,0,11.333q�6v   $��23��6�   ��6#   �� *	owners_id+6�   �� 5'   
   $��1��6.   $	��600��6>   $��1��6J   $
��Left=�6W   $��0,3.667,0,10.667q�6r   $��23��6�   ��6   �� *	last_name+6�   �� 5(   
    �� 	MaxLength$ 50��60   $	��600��6?   $��1��6K   $��2��6[   $
��Left=�6h   $��0,3.333,0,11q�6�   $��23��6�   ��6   �� *
first_name+6�   �� 5)   
   $��1��60   $��3��6@   $	��600��6M   $
��Left=�6Y   $��0,3,0,11.333q�6t   $��23��6�   ��6   �� *middle_name+6�   �� 5*   
   $��1��64   $	��600��6D   $��4��6P   $
��Left=�6]   $��0,3.667,0,10.667q�6x   $��23��6�   ��6   �� *passport_number+6�   �� 5+   
   $ 50��65   $	��600��6D   $��1��6P   $��5��6`   $
��Left=�6m   $��0,3.333,0,11q�6�   $��23��6�   ��6   �� *passport_series+6�   �� 5,   
   $��1��6)   $��6��69   $	��600��6F   $
��Left=�6R   $��0,3,0,11.333q�6m   $��23��6�   ��6   �� *city+6�   �� 5-   
   $��1��6*   $	��600��6:   $��7��6F   $
��Left=�6S   $��0,3.667,0,11.333q�6n   $��23��6�   ��6   �� *phone+6�   �� 5.   
   -   5        $��BtnSave��5.   F   $��Сохранить��6   $��2��6%   $��8��69   5/      51      52      