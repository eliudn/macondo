<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <style type="text/css">
    	.download-link {
  text-decoration: none;
  border: 1px solid #ccc;
  padding: .5em;
  font-family: Helvetica;
  color: #c00;
  display: block;
  text-align: center;
  margin: 1em 0;
}
    </style>

 
</head>
<body>




    <form id="form1" runat="server">
    	<input type="button" name="" value="descarga" onclick="document.location.download='http://macondo.programaciclon.edu.co/web/Estrategia_2/web/2017-02-17_091842_101701.pdf'"  >
     
        	 <a href='"http://macondo.programaciclon.edu.co/web/Estrategia_2/web/2017-02-17_091842_101701.pdf","http://macondo.programaciclon.edu.co/web/Estrategia_2/web/2017-05-04_220417_6587.pdf"'' download='"~/1/e.pdf","~/2/e.pdf"'  class="download-link">Bad ID</a>

    </form>


</body>
</html>


