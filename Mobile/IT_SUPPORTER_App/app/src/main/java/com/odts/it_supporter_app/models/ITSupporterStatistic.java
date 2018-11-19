package com.odts.it_supporter_app.models;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class ITSupporterStatistic {
    @SerializedName("ITSupporterId")
    private Integer itSupporterId;
    @SerializedName("ITSupporterName")
    private String itSupporterName;
    @SerializedName("TotalTimeSupport")
    private String totalTimeSupport;
    @SerializedName("TotalTimesSupport")
    private String totalTimesSupport;
    @SerializedName("TotalTimesSupportInThisMonth")
    private String totalTimesSupportInThisMonth;
    @SerializedName("TotalTimesSupportInThisMonth")
    private String totalTimeSupportInThisMonth;
    @SerializedName("RequestOfITSupporter")
    private List<RequestGroupMonth> requestOfITSupporter;

    public ITSupporterStatistic() {
    }

    public Integer getItSupporterId() {
        return itSupporterId;
    }

    public void setItSupporterId(Integer itSupporterId) {
        this.itSupporterId = itSupporterId;
    }

    public String getItSupporterName() {
        return itSupporterName;
    }

    public void setItSupporterName(String itSupporterName) {
        this.itSupporterName = itSupporterName;
    }

    public String getTotalTimeSupport() {
        return totalTimeSupport;
    }

    public void setTotalTimeSupport(String totalTimeSupport) {
        this.totalTimeSupport = totalTimeSupport;
    }

    public String getTotalTimeSupportInThisMonth() {
        return totalTimeSupportInThisMonth;
    }

    public void setTotalTimeSupportInThisMonth(String totalTimeSupportInThisMonth) {
        this.totalTimeSupportInThisMonth = totalTimeSupportInThisMonth;
    }

    public List<RequestGroupMonth> getRequestOfITSupporter() {
        return requestOfITSupporter;
    }

    public void setRequestOfITSupporter(List<RequestGroupMonth> requestOfITSupporter) {
        this.requestOfITSupporter = requestOfITSupporter;
    }

    public String getTotalTimesSupport() {
        return totalTimesSupport;
    }

    public void setTotalTimesSupport(String totalTimesSupport) {
        this.totalTimesSupport = totalTimesSupport;
    }

    public String getTotalTimesSupportInThisMonth() {
        return totalTimesSupportInThisMonth;
    }

    public void setTotalTimesSupportInThisMonth(String totalTimesSupportInThisMonth) {
        this.totalTimesSupportInThisMonth = totalTimesSupportInThisMonth;
    }
}
