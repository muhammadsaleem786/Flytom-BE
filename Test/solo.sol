// SPDX-License-Identifier: MIT

pragma solidity ^0.8.0;

contract migrator{

    struct strdetails{
        bool check;
        bool isMinted;
        uint256 noOfCities;
        uint256 noOfDistricts;
        uint256 noOfMansions;
        uint256 noOfPlaymates;
        address user;
    }
    struct rlcDetails{
        bool isMinted;
        uint256 noofRedchain;
        uint256 noOfBlackchain;
        uint256 noOfPlatinumchain;
        uint256 noOfScarletToken;
        address user;
    }

    address[] RequiredUsers;
    address[] MintedUsers;
    mapping (address => strdetails) private getDetails;
    mapping (address => rlcDetails) private getRlcDetails;
    address private _owner; 
    address private _manager;


    constructor(address owner , address manager){
        _owner = owner;
        _manager = manager;
    }

    modifier onlyManager{
        require(msg.sender == _manager, "Not authroized");
        _;
    }
    modifier onlyOwner{
        require(msg.sender == _owner, "Not authroized from owner");
        _;
    }

    function AddDetails(uint256 noCities, uint256 noDistricts, uint256 noMansions, uint256 noPlaymates, address user) public{
        if(!getDetails[user].check)
        {
            getDetails[user].noOfCities = noCities;
            getDetails[user].noOfDistricts = noDistricts;
            getDetails[user].noOfMansions = noMansions;
            getDetails[user].noOfPlaymates = noPlaymates;
            getDetails[user].check = true;
            getDetails[user].user = user;

            RequiredUsers.push(user);
        }
        else
        {
            revert("User already swapped");
        }
    }

    function getUserDetails(address user) public view returns(strdetails memory){
        return getDetails[user];
    }

    function ConfirmMinting(address user) public {
        

        for(uint i = 0; i< RequiredUsers.length; i++){
            if(RequiredUsers[i] == user){
                remove(i);
            }  
        }
        getDetails[user].isMinted = true;
        getRlcDetails[user].isMinted = true;

        MintedUsers.push(user);
    }

    function AddRlcDetails(uint256 noRedchain, uint256 noBlackchain, uint256 noPlatinumchain,uint256 noscarlettoken, address user) public{
        if(!getRlcDetails[user].isMinted){
            getRlcDetails[user].noofRedchain = noRedchain;
            getRlcDetails[user].noOfBlackchain = noBlackchain;
            getRlcDetails[user].noOfPlatinumchain = noPlatinumchain;
            getRlcDetails[user].noOfScarletToken = noscarlettoken;
            //getRlcDetails[user].isMinted = true;
        }
        else{
            revert("Already minted nfts");
        }
    }

    function getUserRlcDetails(address user) public view returns(rlcDetails memory){
        return getRlcDetails[user];
    }

    function GetUsersList() public view returns(address[] memory){
        return RequiredUsers;
    }

    function GetMintedUsersList() public view returns(address[] memory){
        return MintedUsers;
    }

    function remove(uint index) private {
        address[] storage userchain = RequiredUsers;
        userchain[index]= userchain[userchain.length-1];
        userchain.pop();
        RequiredUsers = userchain;
    }
    function setManager(address manager) public onlyOwner{
        _manager = manager;
    }
    function getManager() public view returns(address manager){
        return _manager;
    }
}