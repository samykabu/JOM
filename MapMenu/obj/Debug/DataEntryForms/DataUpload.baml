   M S B A M L   `   `   `  ����Q  MJOM Interactive Report, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MapMenu.EntryFormsMapMenu.EntryForms  5      #    MapMenu.EntryForms.DataUpload   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      5
EntryForms clr-namespace:MapMenu.EntryForms    5      -   5        $��DataUploadW��5   �     � Title$  
DataUpload��6   $	��719��6   $	��862��6%    � WindowStartupLocation$ CenterScreen=�61    � WindowStyle$ 
ToolWindow=�6V    � 
ResizeMode$ NoResize=�6o    � Topmost .  � 	Resources 5      +   %MapMenu.EntryForms.ImagePathConverter   LocalUriToImageConverter��%   &	          5   
   6(   5      .��5	      �� $	��684��6   $��0,0,0,0q�6   .+�5
   
   �� -   5        $��label1��5
   J   $��28��6   $
��Left=�6   $��	12,12,0,0q�67   $	��Top=�6X   $	��120��6p   .��6|   Metadata Catigory6�   �� 5   
   -   5        $��label2��5   J   $��28��6   $
��Left=�6   $��	12,12,0,0q�67   $	��Top=�6X   $	��231��6p    �� Left$ 0��6|   
 �� Top$ 63��6�   .��6�   Drag / Drop Files Here6�   �� 5   
   -   5        $��	comboBox1��5   A   $	 138��6   $ 17��6%   $��23��65   $	��282��6R    �� SelectedIndex$ 0��6^   5      �� 5   
   -   5        $��listBox1��5   A   $ 12��6   $	 104��6#   $	��520��64   $	��816��6Q   	 J� 	AllowDrop	 . 
���   �$��Disabled=�6�   ��6�   �� 
 �� Path$
 Files� �� ElementName$ DataUploadW�� �� Mode$ TwoWay=���5      �� 5      .R�5      �� ���	#88000000
�������$��2q�6G    �� CornerRadius$ 6��6[   $��5,5,5,5q�6l   ._�5      �� $	��256��6%   $	��230��61   .+�5      �� $
��Auto��6%   $��20��62   $��0,0,0,0q�6>   .+�5   "   �� -   5        $��20��5   <   $��20��6G   $ 0��6S   ��5   &   �� 5   *   .R�5   .   �� $��Right=�64    J� OpacityMask �	#FF000000$��/Images/Remove.png��6j   5   +    � ToolTip$) #Click to remove the image from list��5   6   5   #   �� 5   "   $��20��6)   $��20��64   $ 25��6@   ��5   &   �� 5    *   .R�5!   .   �� $��Right=�64    �	#FF000000$��/Images/Warning.png��6�   y�6i   �� *HasValidTitle+6�   5"   +   $ This image has no title.��5&   6   5'   #   �� 5(   "   $��20��6)   $��20��64   $ 50��6@   ��5)   &   �� 5*   *   .R�5+   .   �� $��Right=�64   $��/Images/database.png��6v   y�6R   �� *IsInDataBase+6v   5,   +   $$ This file exit in the databae.��50   6   51   #   53      �� 54      ���	#00FFFFFF
�������$��30��6q   $��14(�6}   ��6P   �� $
 CatName�6}   �� 55      ���	#00FFFFFF
�������$��30��6o   $��20(�6{   ��6S   �� $
 Title�6{   �� 56      $	��Top=�6&   $	��256��6>   $	��160��6J   $��Uniform=�6�   ��6W   �� $
 FileName� �� 	Converter# [  6�   58      59      5:      ��5<      �� 5=      .R�5>      � $	��850��6    $��Disabled=�6,   $��Visible=�6b   $
��Left=�6�   5?      5A      �� 5B   
   -   5        $��Month��5B   A   $	 138��6   $ 46��6%   $��23��65   $��75��6N    �� Text$ Month��6Y   $ 0��6f   .@�5C      �� .��6   016   �� 5D      .��6   026   �� 5E      .��6   036   �� 5F      .��6   046   �� 5G      .��6   056   �� 5H      .��6   066   �� 5I      .��6   076   �� 5J      .��6   086   �� 5K      .��6   096   �� 5L      .��6   106   �� 5M      .��6   116   �� 5N      .��6   126   5O      �� 5P   
   -   5        $
��Year��5P   A   $	 219��6   $ 46��6%   $��23��65   $��75��6M   $
 Year��6X   $ 0��6d   .@�5Q      �� .��6   20096!   �� 5R      .��6   20106!   �� 5S      .��6   20116!   �� 5T      .��6   20126!   5U      �� 5V   
   -	   5        $��CancelBT��5V   @   $	 753��6   $	 630��6#   $��24��64   $��75��6P   .��6p   Cancel6x   �� 5W   
   -
   5        $��SaveBT��5W   @   $	 672��6   $	 630��6#   $��24��64   $��76��6N   .��6n   Save6t   �� 5X   
   -   5        $��label4��5X   =   $ 12��6   $ 41��6!   $��28��61   $	��120��6K   .��6W   
Entry Date6c   �� 5Y   
   -   5        $��	ClearList��5Y   ?   $ 13��6   $	 630��6"   $��24��63   $��75��6P   $ Clear All items��6o   .��6�   
Clear List6�   �� 5Z   
   -   5        $��
SavingInfo��5Z   ?   $	 121��6   $	 630��6"   $��28��63   $	��537��6Q   $
��Bold"�6]   $��12(�6o   
���   � � ForceCursor .  6�   5\      5]      