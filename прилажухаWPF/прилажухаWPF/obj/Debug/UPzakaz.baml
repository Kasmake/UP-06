   M S B A M L   `   `   `  ����P  LприлажухаWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:прилажухаWPFприлажухаWPF  5   	   #    прилажухаWPF.UPzakaz   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:прилажухаWPF     5   	   -   5          �Name$  UPzakaz1��5   	    � Title$ UPzakaz��5   	   $	��450��6   $	��800��6&   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5
   �   $
��Left=�6   $	��400��60   $��	10,10,0,0q�6=   $	��Top=�6P   $	��601��6h      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	id_zakaza��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	id_zakaza+6V     5      $ 
id_klienta��6D   $	 100 6X    6%   �� *
id_klienta+6X     5      $ 	id_zapisi��6C   $	 100 6V    6%   �� *	id_zapisi+6V     5      $ 
DataZakaza��6D   $	 100 6X    6%   �� *
DataZakaza+6X     5      $ SummaZakaza��6E   $	 100 6Z    6%   �� *SummaZakaza+6Z     5      $ OtsutstvieZapisi��6J   $	 100 6d    6%   �� *OtsutstvieZapisi+6d   5      �� 5   
   -   5         ��Name$ Grid2��5      $	��219��5      $��5��5      $��608,10,0,12q�5      $
��Left=�5      	 J� RenderTransformOrigin$	 1.549,0.487&�5      .+�5      �� $!��Колонка - id_klienta��6   $��Center=�63   $��0 0 0 0q�6P   �� 5      -   5        
 ��Name$
 
id_klienta��5      $	��100��6*   $��20��66   $��0 0 0 10q�6B   $��
id_klienta��6T   �� 5      $ ��Колонка - id_zapisi��6   $��Center=�62   $��0 0 0 0q�6O   �� 5      -   5        $
 	id_zapisi��5      $	��100��6)   $��20��65   $��0 0 0 10q�6A   $��	id_zapisi��6S   �� 5       $!��Колонка - DataZakaza��6   $��Center=�63   $��0 0 0 0q�6P   �� 5!      -   5        $
 
DataZakaza��5!      $	��100��6*   $��20��66   $��0 0 0 10q�6B   $��
DataZakaza��6T   �� 5#      $"��Колонка - SummaZakaza��6   $��Center=�64   $��0 0 0 0q�6Q   �� 5$      -   5        $
 SummaZakaza��5$      $	��100��6+   $��20��67   $��0 0 0 10q�6C   $��SummaZakaza��6U   �� 5&      $'��!Колонка - OtsutstvieZapisi��6   $��Center=�69   $��0 0 0 0q�6V   �� 5'      -   5        $
 OtsutstvieZapisi��5'      $	��100��60   $��20��6<   $��0 0 0 10q�6H   $��OtsutstvieZapisi��6Z   �� 5*      -	   5         ��Name$ 	addButton��5*      $	��142��6(   $��
10,10,20,0q�5+      $#��Добавить запись��5,      $��14(�5-      6   �� 5/      -
   5        $ insertButton��5/      $	��142��6+   $��
10,10,20,0q�50      $#��Изменить запись��52      $��14(�53      �� 55      -   5        $ deleteButton��55      $��
10,10,20,0q�6+   $��14(�57      $!��Удалить запись��6   $	��144��68   58      5:      5;      