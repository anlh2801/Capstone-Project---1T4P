package com.odts.it_supporter_app.models;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class ITSupporterStatistic {
    @SerializedName("ITSupporterId")
    private Integer itSupporterId;
    @SerializedName("ITSupporterName")
    private String itSupporterName;
    @SerializedName("TotalTimesSupport")
    private Integer totalTimesSupport;
    @SerializedName("TotalTimeSupport")
    private String totalTimeSupport;
    @SerializedName("TotalTimesSupportInThisMonth")
    private Integer totalTimesSupportInThisMonth;
    @SerializedName("TotalTimeSupportInThisMonth")
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

    public Integer getTotalTimesSupport() {
        return totalTimesSupport;
    }

    public void setTotalTimesSupport(Integer totalTimesSupport) {
        this.totalTimesSupport = totalTimesSupport;
    }

    public String getTotalTimeSupport() {
        return totalTimeSupport;
    }

    public void setTotalTimeSupport(String totalTimeSupport) {
        this.totalTimeSupport = totalTimeSupport;
    }

    public Integer getTotalTimesSupportInThisMonth() {
        return totalTimesSupportInThisMonth;
    }

    public void setTotalTimesSupportInThisMonth(Integer totalTimesSupportInThisMonth) {
        this.totalTimesSupportInThisMonth = totalTimesSupportInThisMonth;
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
}
