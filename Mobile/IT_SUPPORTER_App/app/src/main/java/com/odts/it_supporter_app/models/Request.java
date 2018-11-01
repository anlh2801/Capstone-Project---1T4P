package com.odts.it_supporter_app.models;

import com.google.gson.annotations.SerializedName;

public class Request {
    @SerializedName("RequestId")
    private Integer requestId;
    @SerializedName("RequestName")
    private String requestName;
    @SerializedName("AgencyName")
    private String agencyName;
    @SerializedName("Ticket")
    private Ticket ticket;

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

    public Ticket getTicket() {
        return ticket;
    }

    public void setTicket(Ticket ticket) {
        this.ticket = ticket;
    }
}
