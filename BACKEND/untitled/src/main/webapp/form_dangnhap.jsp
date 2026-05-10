<%@page pageEncoding="utf-8"%>
<form action="/untitled/login" method="post">
    Username: <input type="text" name="username" >
    Password: <input type="password"  name="password">
    <button type="submit">Login</button>
    <i style="color: red">${thongbao}</i>
</form>