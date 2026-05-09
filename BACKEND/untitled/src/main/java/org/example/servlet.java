package org.example;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

import java.io.IOException;

@WebServlet("/login")
public class servlet extends HttpServlet {
    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        String usn = req.getParameter("username");
        String pass = req.getParameter("password");

        if (usn.equals("Long") && pass.equals("12345")){
            req.getRequestDispatcher("/LoginThanhCong.jsp").forward(req,resp);

        }else {
            req.getRequestDispatcher("/index.jsp").forward(req,resp);
        }
    }
}
