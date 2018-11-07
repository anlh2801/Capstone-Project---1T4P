package com.odts.models;

import com.google.gson.annotations.SerializedName;

public class Agency {
    @SerializedName("AgencyId")
    private Integer agencyId;
    @SerializedName("AgencyName")
    private String agencyName;
    @SerializedName("Address")
    private String Address;
    @SerializedName("AccountId")
    private Integer accountId;
    public Agency() {
    }

    public Integer getAgencyId() {
        return agencyId;
    }

    public void setAgencyId(Integer agencyId) {
        this.agencyId = agencyId;
    }

    public Integer getAccountId() {
        return accountId;
    }

    public void setAccountId(Integer accountId) {
        this.accountId = accountId;
    }

    public Agency(Integer agencyId, Integer accountId) {

        this.agencyId = agencyId;
        this.accountId = accountId;
    }

    public String getAgencyName() {
        return agencyName;
    }

    public void setAgencyName(String agencyName) {
        this.agencyName = agencyName;
    }

    public String getAddress() {
        return Address;
    }

    public void setAddress(String address) {
        Address = address;
    }
}
