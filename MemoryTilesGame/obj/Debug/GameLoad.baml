   M S B A M L   `   `   `  ����J  FMemoryTilesGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MemoryTilesGameMemoryTilesGame  5   	       MemoryTilesGame.GameLoad   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:MemoryTilesGame     5   	     � Title$  GameLoad��5   	   $��532.9��6   $	��799��6)    � 	Resources 5	         ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius ��Name �� Triggers	 P� Property
 P� Value��%i  &	        �� 5
   
   " ��6$   .�5      ��  � ��
 ���� 6+   �� 5       � ��$ 25(�6)   �� 5       � ��
 �����6+   �� 5       � ��$ 80��6'   �� 5       � ��$	 150��6&   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 7,7,7,7��6!   #��z��68   ._�5      �� $ contentPresenter��6/   #��z��6I   #��z��6}   #��z��6�   #��z��6�   #��z��6	  5      5      5       5      P� 5      	 �@J�IsMouseOver
 . . �5      ��  � ��$ 30(�61   �� 5       �@�Cursor$
 Hand��6/   5      5      5       .��5!      � .+�5"   
   �� -   5        $��ShowUsername��5"      $��64,120,399,347q�6(   
���������6S   �� *UserNameBinding+6w   �� 5#   
   $D��>C:\Users\olivia\OneDrive\Desktop\tema1\MemoryTilesGame\bgi.jpg��6   $��Center=�6X   $
��Fill=�6s   �� 5$   
   -   5        $��ShowPicture��5$      $
��Left=�6#   $	��215��6>   $��128,145,0,0q�6K   $	��Top=�6`   $	��213��6x   A� 5%   
    A� Rows$ 4��6    A� Columns$ 1��6   $
��Left=�6+   $	��Top=�6F   $	��252��6^   $	��274��6k   $��405,122,0,0q�6w   .+�5&      �� -   5         ��Name$ NewGameButton��5&   N   $��New Game��6   #��[  6)   $	��NaN��6�   $	��NaN��6�   $��
57,16,32,4q�6�   �� 5'      -   5        $ LoadGameButton��5'   O   $��	Load Game��6   #��[  6*   $	��NaN��6�   $	��NaN��6�   $��
57,17,32,0q�6�   �� 5(      -   5        $ StatisticsButton��5(   P   $��
Statistics��6   #��[  6+   $	��NaN��6�   $	��NaN��6�   $��
57,16,32,7q�6�   �� 5)      -   5        $ 
ExitButton��5)   _   $
��Back��6   $��57,17,32,10q�6$   #��[  6:   $	��NaN��6�   $	��NaN��6�   5*      �� 5+   
   -   5        $��l1��5+      $��
Won Games:��6   $��27,368,600,77q�6/   
�������$��20(�6Y    J� RenderTransformOrigin$ -0.034,0.446&�6g   �� 5,   
   -   5        $��WonGames��5,      $��143,368,394,77q�6    
�������$��20(�6K   �� 5-   
   -	   5        $��l2��5-      $��Played Games:��6   $��27,404,617,45q�62   
�������$��20(�6\   �� 5.   
   -
   5        $��PlayedGames��5.      $��159,404,420,45q�6#   
�������$��20(�6N   5/      50      