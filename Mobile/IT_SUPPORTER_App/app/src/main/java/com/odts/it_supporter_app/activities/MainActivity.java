package com.odts.it_supporter_app.activities;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.odts.it_supporter_app.R;
import com.odts.it_supporter_app.models.Company;
import com.odts.it_supporter_app.services.CompanyService;
import com.odts.it_supporter_app.utils.CallBackData;

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
                String a = "ITSupport\n";
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
