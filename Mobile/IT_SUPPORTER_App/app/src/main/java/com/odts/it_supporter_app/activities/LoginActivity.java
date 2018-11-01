package com.odts.it_supporter_app.activities;

import android.content.Intent;
import android.content.SharedPreferences;
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
    SharedPreferences sp;
    SharedPreferences share;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        sp = getSharedPreferences("loginHero",MODE_PRIVATE);
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
                loginService.checkLogin(LoginActivity.this, usernameStr, passwordStr, 2);
            }
        });
    }
    public void goToMainActivity(){
        onNewIntent(getIntent());
        Intent i = new Intent(this,MainActivity.class);
        startActivity(i);
        finish();
    }
    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        Bundle extras = intent.getExtras();
        if (extras != null) {
            share = getSharedPreferences("firebaseData", MODE_PRIVATE);
            SharedPreferences.Editor editor = share.edit();
            editor.putString("a",extras.getString("AgencyName"));
            editor.putString("b",extras.getString("AgencyAddress"));
            editor.putString("c",extras.getString("TicketsInfo"));
            editor.putString("d",extras.getString("RequestName"));
            editor.putString("e",extras.getString("RequestId"));
            editor.commit();
        }
    }
}
