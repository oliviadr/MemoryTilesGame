   M S B A M L   `   `   `  ����J  FMemoryTilesGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MemoryTilesGameMemoryTilesGame  5   	        MemoryTilesGame.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:MemoryTilesGame     5   	     � Title$  SignIn��5   	   $��532.9��6   $	��799��6'    � 	Resources 5	         ButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius ��Name �� Triggers	 P� Property
 P� Value��%i  &	        �� 5
   
   " ��6$   .�5      ��  � ��
 ���� 6+   �� 5       � ��$ 25(�6)   �� 5       � ��
 �����6+   �� 5       � ��$ 80��6'   �� 5       � ��$	 150��6&   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ 7,7,7,7��6!   #��z��68   ._�5      �� $ contentPresenter��6/   #��z��6I   #��z��6}   #��z��6�   #��z��6�   #��z��6	  5      5      5       5      P� 5      	 �@J�IsMouseOver
 . . �5      ��  � ��$ 30(�61   �� 5       �@�Cursor$
 Hand��6/   5      5      5       .��5!      � .+�5"   
   �� $E��?C:\Users\olivia\OneDrive\Desktop\tema1\MemoryTilesGame\bgi1.jpg��6   $��Center=�6Y   $
��Fill=�6t   �� 5#   
   $
��Bold"�6    �� TextAlignment$ Center=�6&   $��30(�6=   
�������$��0,56,0,0q�6^   Select your Profile6�   �� 5$   
   -   5        $��UsersListView��5$      $��25(�6(   
������ 
�������
�������$��96,152,400,126q�6v    �� View 5%      �� 5&      .P�5(      ��  �� DisplayMemberBinding 6%   �� *UserNameBinding+6X   5)      5+      �� 5,   
   -   5        $��ShowPicture��5,      $
��Left=�6#   $	��215��6>   $��461,164,0,0q�6K   $	��Top=�6`   $	��213��6x   A� 5-   
    A� Rows$ 1��6    A� Columns$ 4��6   $
��Left=�6+   $	��Top=�6F   $��86��6^   $��128,396,0,0q�6j   $	��610��6   .+�5.      �� -   5         ��Name$ newUserButton��5.   M   $��Add User��6   #��[  6(   6f   �� 5/      -   5        $ deleteUserButton��5/   P   $��Delete User��6   #��[  6+   6l   �� 50      -   5        $ 
playButton��50   J   $
��Play��6   #��[  6%   6^   �� 51      -   5        $ 
exitButton��51   J   $
��Exit��6   #��[  6%   6^   52      54      55      