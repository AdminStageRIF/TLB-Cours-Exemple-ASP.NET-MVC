<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Exemple_00.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
  <title>Démo asp.net</title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <h1>Il est <% =DateTime.Now.ToString("hh:mm:ss") %></h1>
    </div>
  </form>
</body>
</html>
