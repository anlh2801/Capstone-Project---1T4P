package com.odts.activities;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.odts.services.CompanyService;
import com.odts.utils.CallBackData;
import com.odts.models.Company;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {
    private CompanyService _companyService;
    private TextView textView;
    Button btnAdd;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        textView = (TextView) findViewById(R.id.testID);

        _companyService = new CompanyService();
        _companyService.getAllCompany(MainActivity.this, new CallBackData<ArrayList<Company>>() {
            @Override
            public void onSuccess(ArrayList<Company> companies) {
                String a = "";
                for (Company com : companies) {
                    a = a + com.getCompanyName() + " - " + com.getUpdateDate() + "\n";
                }
                textView.setText(a);
            }

            @Override
            public void onFail(String message) {

            }
        });
        btnAdd = (Button) findViewById(R.id.btnAdd);
        btnAdd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(MainActivity.this, RequestActivity.class);
                startActivity(intent);
            }
        });
    }

}
