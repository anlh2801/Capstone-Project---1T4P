package com.odts.it_supporter_app.models;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class Request {
    @SerializedName("RequestId")
    private Integer requestId;
    @SerializedName("RequestName")
    private String requestName;
    @SerializedName("AgencyName")
    private String agencyName;
    @SerializedName("AgencyTelephone")
    private String agencyTelephone;
    @SerializedName("Tickets")
    private List<Ticket> tickets;

    public String getAgencyTelephone() {
        return agencyTelephone;
    }

    public void setAgencyTelephone(String agencyTelephone) {
        this.agencyTelephone = agencyTelephone;
    }

    public Integer getRequestId() {
        return requestId;
    }

    public void setRequestId(Integer requestId) {
        this.requestId = requestId;
    }

    public String getRequestName() {
        return requestName;
    }

    public void setRequestName(String requestName) {
        this.requestName = requestName;
    }

    public String getAgencyName() {
        return agencyName;
    }

    public void setAgencyName(String agencyName) {
        this.agencyName = agencyName;
    }

    public List<Ticket> getTicket() {
        return tickets;
    }

    public void setTicket(Ticket ticket) {
        this.tickets = tickets;
    }
}
