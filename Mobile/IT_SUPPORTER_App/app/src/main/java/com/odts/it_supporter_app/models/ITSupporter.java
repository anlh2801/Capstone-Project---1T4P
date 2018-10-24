package com.odts.it_supporter_app.models;

import com.google.gson.annotations.SerializedName;

public class ITSupporter {
    @SerializedName("ITSupporterId")
    private Integer itSupporterId;
    @SerializedName("ITSupporterName")
    private String itSupporterName;
    @SerializedName("AccountId")
    private Integer accountId;

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

    public Integer getAccountId() {
        return accountId;
    }

    public void setAccountId(Integer accountId) {
        this.accountId = accountId;
    }
}
