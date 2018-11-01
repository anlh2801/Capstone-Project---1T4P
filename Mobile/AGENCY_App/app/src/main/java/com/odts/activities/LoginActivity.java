package com.odts.activities;

import android.content.Intent;
import android.content.SharedPreferences;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.odts.services.LoginService;

public class LoginActivity extends AppCompatActivity {
    Button btnLogin;
    EditText username;
    EditText password;
    LoginService loginService;
    SharedPreferences sp;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        sp = getSharedPreferences("login",MODE_PRIVATE);

        if(sp.getBoolean("logged",false)){
            goToMainActivity();
        }
        btnLogin = (Button) findViewById(R.id.btn_login);
        username = (EditText) findViewById(R.id.input_username);
        password = (EditText) findViewById(R.id.input_password);
        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                loginService = new LoginService();
                String usernameStr = username.getText().toString();
                String passwordStr = password.getText().toString();
                loginService.checkLogin(LoginActivity.this, usernameStr, passwordStr, 3);
            }
        });
    }
    public void goToMainActivity(){
        Intent i = new Intent(this,MainActivity.class);
        startActivity(i);
    }
}
