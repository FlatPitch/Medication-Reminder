   M S B A M L   `   `   `  ����E  ADesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MedicationPCMedicationPC  5   	       MedicationPC.AddUser   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MedicationPC     5   	   -   5          �Name$  AdduserWindow��5   	    � Title$ AddUser��5   	   $	��600��6   $	��604��6&    � 
ResizeMode$ NoResize=�62   .��5	      �  � RowDefinitions 5
   
   �� 5       � ColumnDefinitions 5   
   �� 5      ��5   
   
� 5      .��5      �  � Color$ White��6    � Offset$ 0.763Q�6-   � 5      $ White��6   � 5      $ 	#FF778FFF��6   $
 0.77Q�61   5      .+�5   
   �� -   5         ��Name$ Add_User��5      $��Add User��6#   $
��Left=�66   $��199,386,0,0q�6Q   $	��Top=�6f   $	��200��6~   $��42��6�   $��26(�6�   �� 5   
   -   5         ��Name$ Username��5      $
��Left=�6$   $��35��6?   $��175,199,0,0q�6K   	 �� TextWrapping$
	 Wrap=�6`   $	��Top=�6t   $	��248��6�   $��26(�6�   �� 5   
   -   5        $ password��5      $
��Left=�6$   $��35��6?   $��175,297,0,0q�6K   $
	 Wrap=�6`   $	��Top=�6t   $	��248��6�   $��26(�6�   �� 5   
   -   5        
 ��Name$
 adduserLabel��5      $��Username��6&   $
��Left=�69   $��175,155,0,0q�6T   $	��Top=�6i   $	��248��6�   $��Arial)�6�   $��26(�6�   $
��Bold"�6�   $��44��6�   �� 5   
   -   5        $
 addpassLabel��5      $��Password��6&   $
��Left=�69   $��175,251,0,0q�6T   $	��Top=�6i   $	��248��6�   $��Arial)�6�   $
��Bold"�6�   $��26(�6�   $��44��6�   5      5      