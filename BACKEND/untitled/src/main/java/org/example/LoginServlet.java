package org.example;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;


@WebServlet ("/login")
public class LoginServlet extends HttpServlet {
    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String usn = req.getParameter("username");
        String Pass = req.getParameter("password");

        if (usn.equals("Long") && Pass.equals("123")){
            resp.getWriter().println("Da dang nhap thanh congggg!");
        }else {
            req.setAttribute("thongbao", "sai tk hoac mk");
            req.getRequestDispatcher("index.jsp").forward(req,resp);
        }

    }
}
