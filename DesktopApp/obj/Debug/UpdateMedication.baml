   M S B A M L   `   `   `  ����E  ADesktopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MedicationPCMedicationPC  5   	   #    MedicationPC.UpdateMedication   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MedicationPC     5   	   -   5          �Name$  UpdateMedicationWindow��5   	    � Title$ UpdateMedication��5   	   $	��600��6"   $	��600��6/    � 
ResizeMode$ NoResize=�6;   ��5	      
� 5
   
   .��5      �  � Color$ 	#FF778FFF��6    � Offset$
 0.77Q�6-   � 5      $ White��6   $
 0.76Q�6)   5      .��5      �  J� RenderTransformOrigin$ 0.502,0.508&�6   .+�5   
   �� -   5         ��Name$ updateUsername��5      $
��Left=�6*   $��35��6E   $��206,152,0,0q�6Q    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��174��6�   $��22(�6�   $��Arial)�6�   �� 5   
   -   5         ��Name$ updateUsernameLabel��5      $��Username��6-   $
��Left=�6@   $��227,100,0,0q�6[   $	��Top=�6p   $ -3.684,-0.808&�6�   $��36��6�   $	��152��6�   $��26(�6�   $��Arial)�6�   $
��Bold"�6�   �� 5   
   -   5        $ medicationNameLabel��5      $��Medication ��6-   $
��Left=�6C   $��221,235,0,0q�6^   $	��Top=�6s   $ -3.684,-0.808&�6�   $��36��6�   $	��174��6�   $��26(�6�   $��Arial)�6�   $
��Bold"�6�   �� 5   
   -   5        $ 	timeLabel��5      $
��Time��6#   $
��Left=�62   $��413,232,0,0q�6M   $	��Top=�6b   $ -3.684,-0.808&�6z   $��36��6�   $��74��6�   $��26(�6�   $��Arial)�6�   $
��Bold"�6�   �� 5   
   -   5        $ dosageLabel��5      $��Dosage��6%   $
��Left=�66   $��
89,233,0,0q�6Q   $	��Top=�6e   $ -3.684,-0.808&�6}   $��41��6�   $	��152��6�   $��26(�6�   $��Arial)�6�   $
��Bold"�6�   �� 5   
   -   5        	 ��Name$	 comboBox��5      $
��Left=�6%   $��205,283,0,0q�6@   $	��Top=�6U   $	��174��6m   $��34��6y   $��20(�6�   .@�5      �� $��Amoxicillin��6   $
��Left=�61   $	��181��6L   �� 5      $��Doxycycline��6   $
��Left=�61   $	��181��6L   �� 5      $��	Meloxicam��6   $
��Left=�6/   $	��181��6J   5      �� 5   
   -   5        $	 	comboBox1��5      $
��Left=�6&   $��
76,283,0,0q�6A   $	��Top=�6U   $	��120��6m   $��34��6�   $��20(�6�   .@�5      �� $��1��6   $
��Left=�6'   $	��118��6B   $��22(�6N   �� 5      $��2��6   $
��Left=�6'   $	��118��6B   $��22(�6N   �� 5      $��3��6   $
��Left=�6'   $	��118��6B   $��22(�6N   5      �� 5   
   -	   5        $ timeTextBox��5      $
��Left=�6'   $��35��6B   $��387,282,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��120��6�   $��22(�6�   �� 5    
   -
   5        
 ��Name$
 update_button��5       $��Update��6(   $
��Left=�69   $��228,392,0,0q�6T   $	��Top=�6i   $	��138��6�   $��39��6�   $��20(�6�   5"      5#      