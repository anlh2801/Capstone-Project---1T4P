package com.odts.it_supporter_app.models;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class RequestGroupMonth {
    @SerializedName("MonthYearGroup")
    private String monthYearGroup;
    @SerializedName("RequestOfITSupporter")
    private List<Request> requestOfITSupporter;

    public RequestGroupMonth() {
    }

    public String getMonthYearGroup() {
        return monthYearGroup;
    }

    public void setMonthYearGroup(String monthYearGroup) {
        this.monthYearGroup = monthYearGroup;
    }

    public List<Request> getRequestOfITSupporter() {
        return requestOfITSupporter;
    }

    public void setRequestOfITSupporter(List<Request> requestOfITSupporter) {
        this.requestOfITSupporter = requestOfITSupporter;
    }
}
