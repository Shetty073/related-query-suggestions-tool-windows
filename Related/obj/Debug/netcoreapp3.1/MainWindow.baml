   M S B A M L   `   `   `  ����N  JRelated, Version=0.0.1.0, Culture=neutral, PublicKeyToken=5860de3dca851dfa!clr-namespace:RelatedRelated  5   	       Related.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Related     5   	     � Title$>  8Related - a google search related query suggestions tool��5   	   $	��450��6J   $	��800��6W   .��5	      � .+�5
   
   �� $��Keyword��6   $
��Left=�6"   $��	34,18,0,0q�6=   $	��Top=�6P   $��14(�6h   �� 5   
   -   5         ��Name$ keywordTextBox��5      $��
102,22,0,0q�6*    �� TextWrapping$
 Wrap=�6>   $	��Top=�6R   $��22��6j   $
��Left=�6v   $	��175��6�   �� 5   
   $��Language��6   $
��Left=�6#   $��
303,18,0,0q�6>   $	��Top=�6R    J� RenderTransformOrigin$ 0.139,-0.258&�6j   $��14(�6�   �� 5   
   -   5         ��Name$ languageComboBox��5      $
��Left=�6-   $��
378,21,0,0q�6H   $	��Top=�6\   $	��120��6t   �� 5   
   $��Country��6   $
��Left=�6"   $��
530,18,0,0q�6=   $	��Top=�6Q   $��14(�6i   $ 
0.51,0.593&�6w   �� 5   
   -   5        $ countryComboBox��5      $
��Left=�6,   $��
594,21,0,0q�6G   $	��Top=�6[   $	��120��6s   �� 5   
   -   5         ��Name$ 	searchBtn��5      $��Search��6$   $
��Left=�65   $��	40,62,0,0q�6P   $	��Top=�6c   $��28��6{   $��66��6�   6�   �� 5   
   $��
19,95,19,0q�6   $	��Top=�6(   $��11��6@   �� 5   
   -   5         ��Name$ resultsScrollViewer��5      $��10,132,10,28q�64   $��Normal"�6J   
���   �$��1,1,1,1q�6r   �� 5   
   -   5         ��Name$ resultsLabel��5      $��Results:��6&   $
��Left=�69   $��	3,106,0,0q�6T   $	��Top=�6g   $��26��6   $��14(�6�   � 5   
   -   5         �Name$ progressBar��5      $
��Left=�6+   $��10��6F   $��
59,117,0,0q�6R   $	��Top=�6f   $	��100��6~   	 � IsIndeterminate$
	 True��6�   5      5      