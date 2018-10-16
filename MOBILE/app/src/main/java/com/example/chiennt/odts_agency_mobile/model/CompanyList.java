package com.example.chiennt.odts_agency_mobile.model;

import com.google.gson.annotations.SerializedName;

import java.util.ArrayList;

public class CompanyList {

    @SerializedName("ObjReturn")
    private ArrayList<Company> companyList;

    public ArrayList<Company> getCompanyArrayList() {
        return companyList;
    }

    public void setCompanyArrayList(ArrayList<Company> companyArrayList) {
        this.companyList = companyArrayList;
    }
}
