   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5      $	��450��6   $
��1000��6%   .��5	      �  � 	Resources 5
   
      DateTemplate��%!   &	        �� 5      5      5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��grdCalendar��5         AutoGenerateColumns .  $
��Left=�6Z   $	��311��6u   $��	10,82,0,0q�6�   $	��Top=�6�   $	��970��6�   ��6&   ��    Columns 5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Strike 1��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *	isStrike1+  5      $ Strike 2��6)    6;   �� *	isStrike2+  5      $ Strike 3��6)    6;   �� *	isStrike3+0  *System.Windows.Controls.DataGridTextColumn  5      $ 	Last Name��6%    68   �� *
LastName+  5      $ 
First Name��6%    69   �� *	FirstName+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ 1��6)      CellTemplate# [  64     5      $ 2��6)   # [  64     5      $ 3��6)   # [  64     5      $ 4��6)   # [  64     5      $ 5��6)   # [  64     5      $ 6��6)   # [  64     5      $ 7��6)   # [  64     5      $ 8��6)   # [  64     5      $ 9��6)   # [  64     5      $ 10��6)   # [  65     5       $ 11��6)   # [  65     5!      $ 12��6)   # [  65     5"      $ 13��6)   # [  65     5#      $ 14��6)   # [  65     5$      $ 15��6)   # [  65     5%      $ 16��6)   # [  65     5&      $ 17��6)   # [  65     5'      $ 18��6)   # [  65     5(      $ 19��6)   # [  65     5)      $ 20��6)   # [  65     5*      $ 21��6)   # [  65     5+      $ 22��6)   # [  65     5,      $ 23��6)   # [  65     5-      $ 24��6)   # [  65     5.      $ 25��6)   # [  65     5/      $ 26��6)   # [  65     50      $ 27��6)   # [  65     51      $ 28��6)   # [  65     52      $ 29��6)   # [  65     53      $ 30��6)   # [  65     54      $ 31��6)   # [  65   56      �� 57   
   -   5         ��Name$ AddNewGuestBtn��57      $��	New Guest��6)   $
��Left=�6=   $	��Top=�6X   $��97��6p   $��24��6{   $��
668,41,0,0q�6�   �� 58   
   $��Search for Guest:��6   $
��Left=�6,   $	��Top=�6G   $��
668,10,0,0q�6_   �� 59   
   $
��Left=�6   $��24��6-    �� TextWrapping$
 Wrap=�69   $��
Guest Name��6M   	 �� TextAlignment$
	 Left=�6_   $	��Top=�6t   $	��118��6�   $��
773,10,0,0q�6�   �� 5:   
   $��View Reports��6   $
��Left=�6(   $	��Top=�6C   $��84��6[   $��24��6f   
 J� RenderTransformOrigin$
 	0.5,0.538&�6r   $��
896,41,0,0q�6�   �� 5;   
   -   5        $��Search��5;      $
��Left=�6"   $	��Top=�6=   $��84��6U   $��24��6`   $��
896,10,0,0q�6l   6�   �� 5<   
   $��Update Guest Stays��6   $
��Left=�6.   $	��Top=�6I   $	��118��6a   $��24��6m   $��
773,41,0,0q�6y   �� 5=   
   $��February 2019��6   $
��Left=�6(   $��	10,10,0,0q�6C   $	��Top=�6V   $��25(�6n   $
��Bold"�6|   5>      5?      