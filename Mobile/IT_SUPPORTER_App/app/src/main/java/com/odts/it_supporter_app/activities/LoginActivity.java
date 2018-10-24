package com.odts.it_supporter_app.activities;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.services.LoginService;

public class LoginActivity extends AppCompatActivity {
    Button btnLogin;
    EditText username;
    EditText password;
    LoginService loginService;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        btnLogin = (Button) findViewById(R.id.btn_login);
        username = (EditText) findViewById(R.id.input_username);
        password = (EditText) findViewById(R.id.input_password);
        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                loginService = new LoginService();

                String usernameStr = username.getText().toString();
                String passwordStr = password.getText().toString();
                loginService.checkLogin(LoginActivity.this, usernameStr, passwordStr, 2);
            }
        });
    }
}
