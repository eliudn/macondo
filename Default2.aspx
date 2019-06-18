<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .notifi2
         {
            background-color: #fff;
            border:2px solid #318296;
     
           
            float: right;
            border-collapse: collapse;
          
           
            position: absolute;
            z-index: 400;
            box-shadow: 5px 5px 5px #aaa;
            right: 0px;
            /*top: 82px;*/
            margin-top: -1px;
        }
        /****************************************************
                        Dropdown
****************************************************/
.piluku-dropdown {
  display: inline-block;
  list-style-type: none;
  position: absolute;
    right: 0;
    border:2px solid #000;
}
.piluku-dropdown .dropdown-piluku-menu {
  border-width: 0;
  border-radius: 0;
  background-color: #FFFFFF;
  border-top: 2px solid #2196f3;
  -webkit-transition: all 1s ease-out;
  /*position: absolute;*/
  left: 0;
  max-height: 420px;
  z-index: 99;
  padding: 0;
  overflow: visible;
}
.piluku-dropdown .dropdown-piluku-menu li {
  -webkit-transition: all 300ms ease-out;
  -moz-transition: all 300ms ease-out;
  transition: all 300ms ease-out;
}
.piluku-dropdown .dropdown-piluku-menu li a:hover {
  background-color: #f6f7fa;
  color: #707780;
}
.piluku-dropdown .dropdown-piluku-menu li:hover {
  background-color: #e9ecf2;
}
/*.piluku-dropdown .dropdown-piluku-menu:after {
  content: "";
  position: absolute;
  top: -10px;
  left: 10px;
  margin: auto;
  width: 0;
  height: 0;
  border-style: solid;
  border-width: 0 8px 8px 8px;
  border-color: transparent transparent #2196f3 transparent;
  /*border-color: transparent transparent red transparent;
  z-index: 9999999999999999999999999;
}*/
.piluku-dropdown .dropdown-piluku-menu.dropdown-right {
  right: 0;
  left: auto;
}
.piluku-dropdown .dropdown-piluku-menu.dropdown-right:after {
  right: 10px;
  left: auto;
}
.piluku-dropdown .dropdown-piluku-menu.neat_drop a {
  overflow: hidden;
  display: inline-block;
  display: table;
  width: 100%;
  padding: 10px 0px !important;
  border-bottom: 1px solid #e9ecf2;
  text-decoration: none;
}
.piluku-dropdown .dropdown-piluku-menu.neat_drop a .time_info {
  font-size: 12px;
  font-weight: 300;
  color: #9398a0;
}
.piluku-dropdown .dropdown-piluku-menu.neat_drop a .text_info {
  font-size: 12px;
  font-weight: 400;
  display: block;
  line-height: 16px;
  letter-spacing: 0.10px;
  margin-top: 8px;
  font-family: 'Nunito', sans-serif;
}
.piluku-dropdown .dropdown-piluku-menu.neat_drop a .time_info {
  font-size: 12px;
  font-weight: 300;
  color: #9398a0;
}
.piluku-dropdown .dropdown-piluku-menu.neat_drop .last_info {
  text-align: center;
  color: #707780;
  padding: 15px;
}
.piluku-dropdown .dropdown-piluku-menu.neat_drop .last_info:hover {
  color: #4c5157;
}
.piluku-dropdown .dropdown-piluku-menu.neat_drop li:last-child a {
  border-bottom-width: 0;
}
.piluku-dropdown .dropdown-piluku-menu.notification-drop {
  width: 350px;
}
.piluku-dropdown .dropdown-piluku-menu.language-drop {
  width: 200px;
}
.piluku-dropdown .dropdown-piluku-menu.avatar_drop {
    width: 210px;
    list-style-type:none;
    -webkit-margin-before: 0;
    -webkit-margin-after: 0;
}
.piluku-dropdown .dropdown-piluku-menu.avatar_drop i {
  color: #dadfe7;
  padding-right: 10px;
  font-size: 18px;
}
.piluku-dropdown .dropdown-piluku-menu.avatar_drop > li a.logout_button {
  text-align: center;
  background: #fb5d5d;
  color: #FFFFFF;
  border-radius: 2px;
}
.piluku-dropdown .dropdown-piluku-menu.avatar_drop > li a.logout_button i {
  color: #FFFFFF;
  font-size: 20px;
}
.piluku-dropdown .dropdown-piluku-menu.avatar_drop > li a.logout_button:hover {
  color: #ffffff;
  background-color: #fa4444;
}
.piluku-dropdown .dropdown-piluku-menu.message_drop {
  width: 350px;
}
.piluku-dropdown .dropdown-piluku-menu.message_drop .avatar_left {
  width: 30px;
  display: inline-block;
  float: left;
}
.piluku-dropdown .dropdown-piluku-menu.message_drop .avatar_left img {
  width: 100%;
  border-radius: 50%;
  display: inline-block;
}
.piluku-dropdown .dropdown-piluku-menu.message_drop .info_right {
  float: left;
  display: inline-block;
  width: 90%;
}
.piluku-dropdown .dropdown-piluku-menu.message_drop .info_right .text_head {
  margin-left: 5px;
  margin-bottom: 3px;
}
.piluku-dropdown .dropdown-piluku-menu.message_drop .text_info {
  margin-top: 0 !important;
  /*height: 30px;*/
  clear: both;
  overflow: hidden;
  margin-left: 5px;
  color: #9398a0;
  font-size: 13px;
}
.piluku-dropdown .dropdown-piluku-menu.message_drop .time_info {
  margin-top: 0 !important;
  margin-left: 40px;
}
.piluku-dropdown .dropdown-piluku-menu.message_drop .time_info i {
  font-size: 8px;
}
.piluku-dropdown .dropdown-piluku-menu.message_drop .time_info i.online {
  color: #6fd64b;
}
.piluku-dropdown .dropdown-piluku-menu.message_drop .time_info i.offline {
  color: #fb5d5d;
}
.piluku-dropdown .dropdown-piluku-menu.message_drop .time_info i.away {
  color: #f7941d;
}
.piluku-dropdown .dropdown-piluku-menu.message_drop .time_info i.grey {
  color: #d7dce5;
}
.piluku-dropdown .dropdown-piluku-menu a {
  /*height: 30px;*/
  display: inline-block;
  position: relative;
  font-size: 13px;
  font-weight: 400;
  display: block;
  line-height: 16px !important;
  font-family: 'Nunito', sans-serif;
  white-space: normal;
  color: #707780;
}
.piluku-dropdown .dropdown-piluku-menu a:hover,
.piluku-dropdown .dropdown-piluku-menu a:active,
.piluku-dropdown .dropdown-piluku-menu a:focus {
  background-color: transparent;
  color: #707780 !important;
}
.piluku-dropdown .drop-icon {
  font-size: 10px;
  display: inline-block;
  vertical-align: top;
  padding-left: 5px;
}
    </style>
    <script src="Scripts/jquery-1.9.1.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="notifi">
            <div class="piluku-dropdown dropdown">
			    <ul class="dropdown-menu dropdown-piluku-menu avatar_drop neat_drop dropdown-right" role="menu">
				    <li>
					    <a href="profile.html"> <i class="ion-android-settings"></i>Settings</a>
				    </li>
				    <li>
					    <a href="mailbox.html"> <i class="ion-android-chat"></i>Messages</a>
				    </li>
				    <li>
					    <a href="dropzone-file-upload.html"> <i class="ion-android-cloud-circle"></i>Upload</a>
				    </li>
				    <li>
					    <a href="profile.html"> <i class="ion-android-create"></i>Edit profile</a>
				    </li>
				    <li>
					    <a href="lock-screen.html" class="logout_button"><%--<i class="ion-power"></i>--%>Logout</a>
				    </li>   
			    </ul>
		    </div>
        </div>
    </div>
    </form>
</body>
</html>
