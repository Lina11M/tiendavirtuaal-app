<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentation.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login - Tienda Virtual</title>
    <script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
<script nomodule src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>

    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        .login-container {
            background-color: #fff;
            padding: 40px;
            border-radius: 8px;
            box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
            width: 300px;
            text-align: center;
        }

        h1 {
            font-size: 2rem;
            color: #2a2185;
            margin-bottom: 20px;
        }

        h2 {
            font-size: 1.5rem;
            color: #333;
            margin-bottom: 30px;
        }

        .form-group {
            margin-bottom: 20px;
            text-align: left;
        }

        label {
            font-size: 0.9rem;
            color: #333;
            margin-bottom: 5px;
            display: block;
        }

        input[type="email"], input[type="password"] {
            width: 100%;
            padding: 10px;
            margin-top: 5px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 1rem;
            box-sizing: border-box;
        }

            input[type="email"]:focus, input[type="password"]:focus {
                border-color: #4CAF50;
                outline: none;
            }

        button {
            width: 100%;
            padding: 12px;
            background-color: #4CAF50;
            color: #fff;
            border: none;
            border-radius: 4px;
            font-size: 1.1rem;
            cursor: pointer;
            transition: background-color 0.3s;
        }

            button:hover {
                background-color: #45a049;
            }

        .message {
            margin-top: 20px;
            font-size: 0.9rem;
            color: #d9534f;
        }

            .message.success {
                color: #5bc0de;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h1>Tienda Virtual</h1>
            <h2>Iniciar Sesión</h2>

            <div class="form-group">
                <label for="TBCorreo">
                    <span class="icon">
                        <ion-icon name="mail-outline"></ion-icon>
                    </span>
                    Correo
   
                </label>
                <asp:TextBox ID="TBCorreo" CssClass="input-field" TextMode="Email" runat="server" />
            </div>

            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Contraseña "></asp:Label>
                <asp:TextBox ID="TBContrasena" TextMode="Password" runat="server" />
            </div>

            <asp:Button ID="BtnIngresar" runat="server" Text="Ingresar" OnClick="BtnIngresar_Click" />

            <asp:Label ID="LblMsg" runat="server" Text="" CssClass="message"></asp:Label>
        </div>
    </form>
</body>
</html>
